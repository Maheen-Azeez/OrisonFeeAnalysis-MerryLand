
using OrisonFeeAnalysis.Entities.Financial.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Contract.Financial.Main
{
   public interface IAccountAllocation :IDisposable
    {
        Task<IEnumerable<VoucherAllocation>> AccountAllocation(long AccId,  long VID,int BranchID);
    }
}
