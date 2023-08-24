using OrisonFeeAnalysis.Entities.Financial.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Contract.Financial.Main
{
   public interface IVoucher : IDisposable
    {
      public  Task<Voucher> ShowVoucher(long VId);

    }
}
