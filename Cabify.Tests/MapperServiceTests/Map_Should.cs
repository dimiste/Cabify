using Cabify.Common.Enum;
using Cabify.Models;
using Cabify.ModelsDto;
using Cabify.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.Tests.MapperServiceTests
{
    [TestClass]
    public class Map_Should
    {
        private Product Product { get; set; }

        private ProductDto ProductDto { get; set; }

        public MapperService MapperService { get; set; }

        [TestInitialize]
        public void CreateProductAndProductDto()
        {
            this.Product = new Product()
            {
                Id = Guid.NewGuid(),
                ProductId = "Product1",
                KindsProduct = KindsProduct.MUG,
                Price = 1,
                IsDeleted = true,
            };

            this.ProductDto = new ProductDto()
            {
                ProductId = "ProductDto1",
                KindsProduct = KindsProduct.TSHIRT,
                Price = 2
            };

            this.MapperService = new MapperService();
        }

        [TestMethod]
        public void ReturnsNewProductDto_WhenParameterIsNotNull()
        {
            // Arrange
            var sut = this.MapperService;

            // Act
            var result = this.MapperService.Map(this.Product);

            // Assert
            Assert.AreEqual(this.Product.ProductId, result.ProductId);
            Assert.AreEqual(this.Product.KindsProduct, result.KindsProduct);
            Assert.AreEqual(this.Product.Price, result.Price);
        }

        [TestMethod]
        public void ReturnsNewProduct_WhenParameterIsNotNull()
        {
            // Arrange
            var sut = this.MapperService;

            // Act
            var result = this.MapperService.Map(this.ProductDto);

            // Assert
            Assert.AreEqual(this.ProductDto.ProductId, result.ProductId);
            Assert.AreEqual(this.ProductDto.KindsProduct, result.KindsProduct);
            Assert.AreEqual(this.ProductDto.Price, result.Price);
        }
    }
}
