using Cabify.Common.Enum;
using Cabify.ModelsDto;
using Cabify.ModelsDto.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.ModelsDto
{
    public class ShoppingBasketDto : IShoppingBasketDto
    {

        private double quantityVoucher;
        private double quantityTshirt;
        private double quantityMug;

        public ShoppingBasketDto()
        {
            
        }

        public void PopulateShoppingBasket(double quantityVoucher, double quantityTshirt, double quantityMug)
        {

            if (quantityVoucher == 0 & quantityTshirt == 0 & quantityMug == 0)
            {
                throw new ArgumentNullException("It cant be all the parameters zero");
            }

            if (quantityVoucher < 0 || quantityTshirt < 0 || quantityMug < 0)
            {
                throw new ArgumentNullException("It cant be all the parameters zero");
            }

            this.quantityVoucher = quantityVoucher;
            this.quantityTshirt = quantityTshirt;
            this.quantityMug = quantityMug;

            var products = new HashSet<ProductDto>();

            for (int i = 0; i < quantityVoucher; i++)
            {
                ProductDto voucher = new ProductDto()
                {
                    KindsProduct = KindsProduct.VOUCHER,
                    Price = 5.0
                };
                products.Add(voucher);
            }

            for (int i = 0; i < quantityTshirt; i++)
            {
                ProductDto tshirt = new ProductDto()
                {
                    KindsProduct = KindsProduct.TSHIRT,
                    Price = 20.0
                };
                products.Add(tshirt);
            }

            for (int i = 0; i < quantityMug; i++)
            {
                ProductDto mug = new ProductDto()
                {
                    KindsProduct = KindsProduct.MUG,
                    Price = 7.50

                };
                products.Add(mug);
            }

            this.Products = products;
        }

        public virtual ICollection<ProductDto> Products { get; private set; }

        public bool IsDeleted { get ; set; }
    }
}
