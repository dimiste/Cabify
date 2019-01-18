using Cabify.Common.Enum;
using Cabify.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.IntegrationTests.ProductTests
{
    [TestClass]
    public class Ctor_Should : TestInitializer
    {
        [TestMethod]
        public void CreateProductWithRightProperties()
        {
            // Arrange
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                ProductId = "product 1",
                KindsProduct = KindsProduct.VOUCHER,
                Price = 5.0,
                IsDeleted = false
            };

            this.efDbContext.Products.Add(product);

            this.efDbContext.SaveChanges();

            // Act
            var result = this.efDbContext.Products.Find(product.Id);

            // Assert
            Assert.AreEqual(product.Id, result.Id);
            Assert.AreEqual(product.ProductId, result.ProductId);
            Assert.AreEqual(product.KindsProduct, result.KindsProduct);
            Assert.AreEqual(product.Price, result.Price);
            Assert.AreEqual(product.IsDeleted, result.IsDeleted);

            this.efDbContext.Products.Attach(product);
            this.efDbContext.Products.Remove(product);

            this.efDbContext.SaveChanges();

        }
    }
}
