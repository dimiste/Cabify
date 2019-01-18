using Cabify.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.Models.Contracts
{
    public interface ISalable
    {
        KindsProduct KindsProduct { get; set; }

        double Price { get; set; }
    }
}
