using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using OrisonFeeAnalysis.Entities.Student;
using OrisonFeeAnalysis.Entities;

namespace OrisonFeeAnalysis.Contract
{
    public interface IBoldReportManager
    {
        public Task<List<ExpandoObject>> GetFeeReciept(long id, string accyear);
        public Task<FileStreamResult> GetDocument(string ReportName, long VoucherID,string accyear);
        public FileStreamResult GetReport(string ReportName, DataSource Data);
        Task<List<ReceiptPrint>> GetFeeRecieptByID(long id, int ONO, string AccYear);
        Task<List<ReceiptPrint>> GetFeeVtype(long VID);

    }
}
