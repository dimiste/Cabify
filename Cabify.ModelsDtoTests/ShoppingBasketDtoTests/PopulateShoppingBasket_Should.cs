using Cabify.ModelsDto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.ModelsDtoTests.ShoppingBasketDtoTests
{
    [TestClass]
    public class PopulateShoppingBasket_Should
    {
        private ShoppingBasketDto shoppingBasketDto;

        [TestInitialize]
        public void CreateShoppingBasketDto()
        {
            this.shoppingBasketDto = new ShoppingBasketDto();
        }

        [TestMethod]
        public void PopulateTheShoppingBasket_WhenAtLeastOneOffParametersIsPositiveNumber()
        {
            // Act
            this.shoppingBasketDto.PopulateShoppingBasket(1, 0, 0);

            var result = this.shoppingBasketDto.Products.Count;

            // Assert
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void ThrowsException_WhenOneOffTheParametersIsNegative()
        {
            // Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => this.shoppingBasketDto.PopulateShoppingBasket(-1, 0, 0));
        }

        [TestMethod]
        public void ThrowsException_WhenOneAllTheParametersAreZero()
        {
            // Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => this.shoppingBasketDto.PopulateShoppingBasket(0, 0, 0));
        }
    }
}
