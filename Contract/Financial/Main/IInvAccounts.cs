using OrisonFeeAnalysis.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Contract.Financial.Main
{
    public interface IInvAccounts
    {
        public Task<IEnumerable<dtInvAccounts>> GetAccountsByCategoryReceipt(string AccCategory, int BranchID);

    }
}
