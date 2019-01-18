using Cabify.Models;
using Cabify.ModelsDto.Contracts;
using Cabify.Services;
using Cabify.Tests.TestServices;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using System.Collections.Generic;

namespace Cabify.Tests.ShoppingBasketServiceTests
{
    [TestClass]
    public class AddShoppingBasket_Should : ShoppingBasketServiceTestsBase
    {
        [TestMethod]
        public void CallsOnceTimeMethodOfAddOffDbSetWrapperAndOnceTimeSaveChanges()
        {
            // Arrange
            ShoppingBasket shoppingBasket = new ShoppingBasket();

            this.shoppingBasketDtoMock.Setup(x => x.Products).Returns(TestsServices.CreateListWithThreeVouchersAndThreeTshirts);

            var sut = new ShoppingBasketService(this.shoppingBasketDtoMock.Object, this.mapperServiceMock.Object, this.efDbSetWrapper.Object, this.efDbContextSaveChanges.Object);

            // Act
            sut.AddShoppingBasket();

            // Assert
            this.efDbSetWrapper.Verify(x => x.Add(It.IsAny<ShoppingBasket>()), Times.Once);
            this.efDbContextSaveChanges.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void CallsAllMethodsNecessaryToAddTheNewBasket()
        {
            // Arrange
            IList<ShoppingBasket> baskets = new List<ShoppingBasket>();
            ShoppingBasket shoppingBasket = new ShoppingBasket();
            this.efDbSetWrapper.Setup(x => x.Add(It.IsAny<ShoppingBasket>())).Callback(() => this.efDbContext.Object.Set<ShoppingBasket>().Add(shoppingBasket));

            this.efDbContext.Setup(x => x.Set<ShoppingBasket>().Add(shoppingBasket)).Callback(() => baskets.Add(shoppingBasket));

            this.shoppingBasketDtoMock.Setup(x => x.Products).Returns(TestsServices.CreateListWithThreeVouchersAndThreeTshirts);

            var shoppingBasketDtoMock = new Mock<IShoppingBasketDto>();

            var sut = new ShoppingBasketService(this.shoppingBasketDtoMock.Object, this.mapperServiceMock.Object, this.efDbSetWrapper.Object, this.efDbContextSaveChanges.Object);

            // Act
            sut.AddShoppingBasket();

            // Assert
            Assert.IsTrue(baskets.Count > 0);
        }
    }
}
