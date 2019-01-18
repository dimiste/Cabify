using Cabify.Common.Enum;
using Cabify.Data;
using Cabify.Data.EfDbSetWrapper;
using Cabify.Models;
using Cabify.ModelsDto;
using Cabify.Services;
using Cabify.Tests.TestServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.IntegrationTests.ShoppingBasketServiceTests
{
    [TestClass]
    public class AddShoppingBasket_Should : TestInitializer
    {
        [TestMethod]
        public void AddShoppingBasketInDB()
        {
            // Arrange
            this.shoppingBasketDto.PopulateShoppingBasket(1, 1, 1);

            // Act
            shoppingBasketService.AddShoppingBasket();
            var shoppingBaskets = this.efDbContext.ShoppingBaskets.Include(s => s.Products);

            // Assert
            Assert.IsTrue(shoppingBaskets.Count() == 1);

            var shoppingBasket = this.efDbContext.ShoppingBaskets.FirstOrDefault();

            var productVoucher = this.efDbContext.Products.Where(p => p.KindsProduct == KindsProduct.VOUCHER).First();
            var productTshirt = this.efDbContext.Products.Where(p => p.KindsProduct == KindsProduct.TSHIRT).First();
            var productMug = this.efDbContext.Products.Where(p => p.KindsProduct == KindsProduct.MUG).First();

            this.efDbContext.Products.Attach(productVoucher);
            this.efDbContext.Products.Attach(productTshirt);
            this.efDbContext.Products.Attach(productMug);

            this.efDbContext.Products.Remove(productVoucher);
            this.efDbContext.Products.Remove(productTshirt);
            this.efDbContext.Products.Remove(productMug);

            this.efDbContext.Set<ShoppingBasket>().Attach(shoppingBasket);
            this.efDbContext.Set<ShoppingBasket>().Remove(shoppingBasket);
            this.efDbContext.SaveChanges();
        }

        
    }
}
