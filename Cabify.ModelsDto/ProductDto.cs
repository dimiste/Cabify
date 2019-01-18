using Cabify.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.ModelsDto
{
    public class ProductDto
    {

        public string ProductId { get; set; }

        public KindsProduct KindsProduct { get; set; }

        public double Price { get; set; }
    }
}
