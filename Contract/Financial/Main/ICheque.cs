using OrisonFeeAnalysis.Entities.Financial.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Contract.Financial.Main
{
 public   interface ICheque : IDisposable
    {
        Task<IEnumerable<Cheque>> ShowCheque(long VId);
        Task<IEnumerable<Cheque>> ShowChequePayment(long VId);
    }
}
