using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cabify.WebClient.Startup))]
namespace Cabify.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
