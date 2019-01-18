using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.Models.Contracts
{
    public interface IDbModel
    {
        Guid Id { get; set; }

        bool IsDeleted { get; set; }
    }
}
