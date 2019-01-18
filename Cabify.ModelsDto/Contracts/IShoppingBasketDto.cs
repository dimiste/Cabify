using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.ModelsDto.Contracts
{
    public interface IShoppingBasketDto
    {
        ICollection<ProductDto> Products { get; }

        bool IsDeleted { get; set; }

        void PopulateShoppingBasket(double quantityVoucher, double quantityTshirt, double quantityMug);
    }
}
