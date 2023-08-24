
using OrisonFeeAnalysis.Entities.Financial.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Contract.Financial.Main
{
    public interface IFinancialManager
    {
        // Task<HttpResponseMessage> CreateFinancial(dtsFinancial Inventory);
        Task<long> CreateFinancial(dtsFinancial Inventory);
    }
}
