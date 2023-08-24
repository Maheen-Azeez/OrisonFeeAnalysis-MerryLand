using OrisonFeeAnalysis.Entities.Financial.Main;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Contract.Financial.Main
{
   public interface IVEntry :IDisposable
    {
        Task<IEnumerable<dtfinVEntry>> Show(long VID);

    }
}
