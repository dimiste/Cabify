using Cabify.Common.Enum;
using Cabify.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.Tests.TestServices
{
    public class TestsServices
    {
        private static List<ProductDto> listProductDto;

        public static List<ProductDto> CreateListWithThreeVouchersAndThreeTshirts()
        {
            listProductDto = new List<ProductDto>()
            {
                new ProductDto() { Price = 5.0, KindsProduct = KindsProduct.VOUCHER },
                new ProductDto() { Price = 20.0, KindsProduct = KindsProduct.TSHIRT },
                new ProductDto() { Price = 5.0, KindsProduct = KindsProduct.VOUCHER },
                new ProductDto() { Price = 5.0, KindsProduct = KindsProduct.VOUCHER },
                new ProductDto() { Price = 7.50, KindsProduct = KindsProduct.MUG },
                new ProductDto() { Price = 20.0, KindsProduct = KindsProduct.TSHIRT },
                new ProductDto() { Price = 20.0, KindsProduct = KindsProduct.TSHIRT }
            };

            return listProductDto;

        }

        public static List<ProductDto> CreateListWithTwoTshirts()
        {
            listProductDto = new List<ProductDto>()
            {
                new ProductDto() { Price = 5.0, KindsProduct = KindsProduct.VOUCHER },
                new ProductDto() { Price = 5.0, KindsProduct = KindsProduct.VOUCHER },
                new ProductDto() { Price = 5.0, KindsProduct = KindsProduct.VOUCHER },
                new ProductDto() { Price = 7.50, KindsProduct = KindsProduct.MUG },
                new ProductDto() { Price = 20.0, KindsProduct = KindsProduct.TSHIRT },
                new ProductDto() { Price = 20.0, KindsProduct = KindsProduct.TSHIRT }
            };

            return listProductDto;

        }
    }
}
