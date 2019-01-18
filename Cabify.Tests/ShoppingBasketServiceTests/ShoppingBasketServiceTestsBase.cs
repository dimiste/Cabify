using Cabify.Data.Contracts;
using Cabify.Models;
using Cabify.ModelsDto.Contracts;
using Cabify.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.Tests.ShoppingBasketServiceTests
{
    public class ShoppingBasketServiceTestsBase
    {
        internal Mock<IShoppingBasketDto> shoppingBasketDtoMock;
        internal Mock<IMapperService> mapperServiceMock;
        internal Mock<IEfDbSetWrapper<ShoppingBasket>> efDbSetWrapper;
        internal Mock<IEfDbContextSaveChanges> efDbContextSaveChanges;
        internal Mock<IEfDbContext> efDbContext;

        [TestInitialize]
        public void CreateDependenciesOfShoppingBasketService()
        {
            this.shoppingBasketDtoMock = new Mock<IShoppingBasketDto>();
            this.mapperServiceMock = new Mock<IMapperService>();
            this.efDbSetWrapper = new Mock<IEfDbSetWrapper<ShoppingBasket>>();
            this.efDbContextSaveChanges = new Mock<IEfDbContextSaveChanges>();
            this.efDbContext = new Mock<IEfDbContext>();
        }
    }
}
