using Bytes2you.Validation;

using Cabify.Common.Enum;
using Cabify.Data;
using Cabify.Data.Contracts;
using Cabify.Data.EfDbSetWrapper;
using Cabify.Models;
using Cabify.ModelsDto.Contracts;
using Cabify.Services.Contracts;
using System;
using System.Linq;

namespace Cabify.Services
{
    public class ShoppingBasketService : IShoppingBasketService
    {
        private readonly IShoppingBasketDto shoppingBasketDto;

        private readonly IMapperService mapperService;

        private readonly IEfDbSetWrapper<ShoppingBasket> efDbSetWrapper;

        private readonly IEfDbContextSaveChanges efDbContextSaveChanges;
    

        public ShoppingBasketService(IShoppingBasketDto shoppingBasketDto, IMapperService mapperService, IEfDbSetWrapper<ShoppingBasket> efDbSetWrapper, IEfDbContextSaveChanges efDbContextSaveChanges)
        {
            Guard.WhenArgument(shoppingBasketDto, "shoppingBasket").IsNull().Throw();

            this.shoppingBasketDto = shoppingBasketDto;
            this.mapperService = mapperService;
            this.efDbSetWrapper = efDbSetWrapper;
            this.efDbContextSaveChanges = efDbContextSaveChanges;
        }

        public double GetTotalPrice()
        {
            var total = this.shoppingBasketDto.Products.Sum(p => p.Price);

            return total;
        }

        private double ApplyDiscounts()
        {
            var totalWithDiscounts = this.GetTotalPrice() - this.ApplyDiscountVoucher() - this.ApplyDiscountTshirt();

            return totalWithDiscounts;
        }

        public double ApplyDiscountVoucher()
        {
            double descount = 0;

            if (this.shoppingBasketDto.Products.Count > 1)
            {
                var productsVoucher = this.shoppingBasketDto.Products.Where(p => p.KindsProduct == KindsProduct.VOUCHER).Count();
                if (productsVoucher > 1)
                {
                    descount = Math.Floor(productsVoucher / 2.0) * 5;
                }
            }

            return descount;
        }

        public double ApplyDiscountTshirt()
        {
            double descount = 0;

            if (this.shoppingBasketDto.Products.Count > 2)
            {
                var productsVoucher = this.shoppingBasketDto.Products.Where(p => p.KindsProduct == KindsProduct.TSHIRT).Count();
                if (productsVoucher > 2)
                {
                    descount = productsVoucher;
                }
            }

            return descount;
        }


        public void AddShoppingBasket()
        {
            var products = this.shoppingBasketDto.Products.Select(p => this.mapperService.Map(p)).ToList();

            ShoppingBasket shoppingBasket = new ShoppingBasket() { Products = products };

            this.efDbSetWrapper.Add(shoppingBasket);

            this.efDbContextSaveChanges.SaveChanges();
        }


    }


}
