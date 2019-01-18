using Cabify.ModelsDto.Contracts;
using Cabify.Services;
using Cabify.Tests.TestServices;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Cabify.Tests.ShoppingBasketServiceTests
{
    [TestClass]
    public class ApplyDiscounts_Should : ShoppingBasketServiceTestsBase
    {
        [TestMethod]
        public void ApplyTwoInOneAndOneEuroless_WhenThereAreTwoOrMuchVouchersAndThreeOrMoreTshirts()
        {
            this.shoppingBasketDtoMock.Setup(s => s.Products).Returns(TestsServices.CreateListWithThreeVouchersAndThreeTshirts());

            ShoppingBasketService sut = new ShoppingBasketService(shoppingBasketDtoMock.Object, mapperServiceMock.Object, efDbSetWrapper.Object, efDbContextSaveChanges.Object);

            //act
            var result = sut.GetTotalPrice() - sut.ApplyDiscountVoucher() - sut.ApplyDiscountTshirt();

            //assert
            Assert.AreEqual(74.5, result);
        }

        [TestMethod]
        public void NotApplyOneEuroLess_WhenThereAreLessOfThreeTshirts()
        {
            //arrange
            shoppingBasketDtoMock.Setup(s => s.Products).Returns(TestsServices.CreateListWithTwoTshirts());

            ShoppingBasketService sut = new ShoppingBasketService(shoppingBasketDtoMock.Object, mapperServiceMock.Object, efDbSetWrapper.Object, efDbContextSaveChanges.Object);

            //act
            var result = sut.GetTotalPrice() - sut.ApplyDiscountVoucher() - sut.ApplyDiscountTshirt();

            //assert
            Assert.AreEqual(57.5, result);
        }
    }
}
