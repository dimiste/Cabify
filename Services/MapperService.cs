using Bytes2you.Validation;

using Cabify.Models;
using Cabify.ModelsDto;
using Cabify.Services.Contracts;

namespace Cabify.Services
{
    public class MapperService : IMapperService
    {
        public ProductDto Map(Product product)
        {
            Guard.WhenArgument(product, nameof(product)).IsNull().Throw();

            return new ProductDto()
            {
                ProductId = product.ProductId,
                KindsProduct = product.KindsProduct,
                Price = product.Price
            };
        }

        public Product Map(ProductDto productDto)
        {
            Guard.WhenArgument(productDto, nameof(productDto)).IsNull().Throw();

            return new Product()
            {
                ProductId = productDto.ProductId,
                KindsProduct = productDto.KindsProduct,
                Price = productDto.Price
            };
        }
    }
}
