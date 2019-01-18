using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.Services.Contracts
{
    public interface IShoppingBasketService
    {
        void AddShoppingBasket();

        double GetTotalPrice();

        double ApplyDiscountVoucher();

        double ApplyDiscountTshirt();
    }
}
