using Cabify.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.Data.Contracts
{
    public interface IEfDbContext
    {
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;

        IDbSet<Product> Products { get; set; }

        IDbSet<ShoppingBasket> ShoppingBaskets { get; set; }
    }
}
