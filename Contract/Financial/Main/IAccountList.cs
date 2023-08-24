using OrisonFeeAnalysis.Entities.Financial.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Contract.Financial.Main
{
   public interface IAccountList
    {
        public Task<IEnumerable<AccountList>> GetAccounts(string AccList, long BranchId, long Userid);
    }
}
