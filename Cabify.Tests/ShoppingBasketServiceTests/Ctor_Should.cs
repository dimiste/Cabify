using Cabify.ModelsDto;
using Cabify.ModelsDto.Contracts;
using Cabify.Services;
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
    public class Ctor_Should : ShoppingBasketServiceTestsBase
    {
        [TestMethod]
        public void ThrowsException_WhenParameterIsNull()
        {
            //Arrange, Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ShoppingBasketService(null, null, null, null));
        }

        [TestMethod]
        public void DoesntThrowException_WhenParameterIsNotNull()
        {
            // Act 
            ShoppingBasketService sut = new ShoppingBasketService(shoppingBasketDtoMock.Object, mapperServiceMock.Object, efDbSetWrapper.Object, efDbContextSaveChanges.Object);

            // Assert
            Assert.IsNotNull(sut);
        }
    }
}
