using Cabify.Models;
using Cabify.ModelsDto;

namespace Cabify.Services.Contracts
{
    public interface IMapperService
    {
        ProductDto Map(Product product);
        Product Map(ProductDto productDto);
    }
}