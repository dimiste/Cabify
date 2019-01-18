using Cabify.Data;
using Cabify.Data.EfDbSetWrapper;
using Cabify.Models;
using Cabify.ModelsDto;
using Cabify.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.IntegrationTests
{
    public class TestInitializer
    {
        internal ShoppingBasketDto shoppingBasketDto;

        internal MapperService mapperService;

        internal EfDbContext efDbContext;

        internal EfDbSetWrapper<ShoppingBasket> efDbSetWrapper;

        internal ShoppingBasketService shoppingBasketService;


        [TestInitialize]
        public void CreateDependenciesOfTests()
        {
            this.shoppingBasketDto = new ShoppingBasketDto();
            this.mapperService = new MapperService();
            this.efDbContext = new EfDbContext();
            this.efDbSetWrapper = new EfDbSetWrapper<ShoppingBasket>(efDbContext);

            this.shoppingBasketService = new ShoppingBasketService(shoppingBasketDto, mapperService, efDbSetWrapper, efDbContext);
        }
    }
}
