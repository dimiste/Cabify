using Cabify.Common.Enum;
using Cabify.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.IntegrationTests.CategoryTests
{
    [TestClass]
     public class Ctor_Should : TestInitializer
    {
        [TestMethod]
        public void CreateShoppingBasketWithRightProperties()
        {
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                ProductId = "product 1",
                KindsProduct = KindsProduct.VOUCHER,
                Price = 5.0,
                IsDeleted = false
            };

            ShoppingBasket shoppingBasket = new ShoppingBasket()
            {
                Id = Guid.NewGuid(),
                Products = new List<Product>() { product },
                IsDeleted = false,
            };

            this.efDbContext.ShoppingBaskets.Add(shoppingBasket);

            this.efDbContext.SaveChanges();

            var result = this.efDbContext.ShoppingBaskets.Find(shoppingBasket.Id);

            Assert.AreEqual(shoppingBasket.Id, result.Id);
            Assert.AreEqual(shoppingBasket.Products, result.Products);
            Assert.AreEqual(shoppingBasket.IsDeleted, result.IsDeleted);

            this.efDbContext.Products.Attach(product);
            this.efDbContext.Products.Remove(product);

            this.efDbContext.ShoppingBaskets.Attach(shoppingBasket);
            this.efDbContext.ShoppingBaskets.Remove(shoppingBasket);

            this.efDbContext.SaveChanges();
        }
    }
}
