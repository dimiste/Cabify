using Cabify.Data.Contracts;
using Cabify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.ServiceDb
{
    public class ProductServices
    {
        public IEfDbSetWrapper<Product> MyProperty { get; set; }


    }
}
