using Cabify.Data.Contracts;
using Cabify.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.Data
{
    public class EfDbContext : DbContext, IEfDbContext, IEfDbContextSaveChanges
    {
        public EfDbContext()
            : base("DefaultConnection")
        {
            this.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<ShoppingBasket> ShoppingBaskets { get; set; }
    }
}
