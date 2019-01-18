using Cabify.Common.Enum;
using Cabify.ModelsDto;
using Cabify.ModelsDto.Contracts;
using Cabify.Services;
using Cabify.Tests.TestServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.Tests.ShoppingBasketServiceTests
{
    [TestClass]
    public class GetTotalPrice_Should : ShoppingBasketServiceTestsBase
    {

        [TestMethod]
        public void ReturnsTotalPriceOfTheProducts()
        {
            //arrange
            shoppingBasketDtoMock.Setup(s => s.Products).Returns(TestsServices.CreateListWithThreeVouchersAndThreeTshirts());

            ShoppingBasketService sut = new ShoppingBasketService(shoppingBasketDtoMock.Object, mapperServiceMock.Object, efDbSetWrapper.Object, efDbContextSaveChanges.Object);

            //act
            var result = sut.GetTotalPrice();

            //assert
            Assert.AreEqual(82.5, result);
        }

        [TestMethod]
        public void ReturnsZero_WhenNotProducts()
        {
            //arrange
            shoppingBasketDtoMock.Setup(s => s.Products).Returns(
                new List<ProductDto>(){});

            ShoppingBasketService sut = new ShoppingBasketService(shoppingBasketDtoMock.Object, mapperServiceMock.Object, efDbSetWrapper.Object, efDbContextSaveChanges.Object);

            //act
            var result = sut.GetTotalPrice();

            //assert
            Assert.AreEqual(0, result);
        }
    }
}
