using Cabify.Common.Enum;
using Cabify.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.Models
{
    public class Product : IDbModel, ISalable
    {
        public Product()
        {
            this.Id = Guid.NewGuid();
        }

        
        public Guid Id { get; set; }

        public string ProductId { get; set; }

        
        public KindsProduct KindsProduct { get; set; }

        
        public double Price { get; set; }

        
        public bool IsDeleted { get; set; }
    }
}
