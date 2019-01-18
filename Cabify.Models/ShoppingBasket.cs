using Cabify.Common.Enum;
using Cabify.Models.Contracts;
using Cabify.ModelsDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.Models
{
    public class ShoppingBasket : IDbModel
    {
        public ShoppingBasket()
        {
            this.Products = new HashSet<Product>();
            this.Id = Guid.NewGuid();
        }

        
        public Guid Id { get; set; }

        
        public virtual ICollection<Product> Products { get; set; }

        
        public bool IsDeleted { get; set; }

    }
}
