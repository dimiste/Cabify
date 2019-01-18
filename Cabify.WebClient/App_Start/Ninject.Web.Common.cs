[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Cabify.WebClient.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Cabify.WebClient.App_Start.NinjectWebCommon), "Stop")]

namespace Cabify.WebClient.App_Start
{
    using System;
    using System.Web;
    using Cabify.Data;
    using Cabify.Data.Contracts;
    using Cabify.Data.EfDbSetWrapper;
    using Cabify.ModelsDto;
    using Cabify.ModelsDto.Contracts;
    using Cabify.Services;
    using Cabify.Services.Contracts;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static IKernel Kernel { get; set; }

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            Kernel = new StandardKernel();
            try
            {
                Kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                Kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(Kernel);
                return Kernel;
            }
            catch
            {
                Kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IEfDbContextSaveChanges), typeof(IEfDbContext)).To(typeof(EfDbContext)).InRequestScope();

            kernel.Bind(typeof(IEfDbSetWrapper<>)).To(typeof(EfDbSetWrapper<>)).InRequestScope();

            kernel.Bind<IShoppingBasketDto>().To<ShoppingBasketDto>().InSingletonScope();

            kernel.Bind<IShoppingBasketService>().To<ShoppingBasketService>();
            kernel.Bind<IMapperService>().To<MapperService>();
        }        
    }
}