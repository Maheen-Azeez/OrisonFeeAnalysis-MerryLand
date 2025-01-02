using Microsoft.AspNetCore.Mvc;
using OrisonFeeAnalysis.Data.BoldReport;
using OrisonFeeAnalysis.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Logics.Contract.BoldReport
{
    public interface IBoldReportManager
    {
        public Task<List<ExpandoObject>> GetRegistrationByID(long id);
        Task<List<ReceiptPrint>> GetFeeRecieptByID(long id, int ONO, string AccYear);
        Task<List<ReceiptPrint>> GetFeeVtype(long VID);
        public Task<List<ExpandoObject>> GetAnalysisData(string Criteria,string Accyear, DateTime DateFrom, DateTime DateTo, int branchID, string Description, string UserName);
        public Task<List<ExpandoObject>> GetAnalysisData(string Criteria,string Accyear, string DateFrom, string DateTo, int branchID, string Description, string UserName);
        public Task<List<ExpandoObject>> FeePaidNotPaid(string Criteria, string Accyear, DateTime DateFrom, DateTime DateTo, int branchID, string Description, string UserName, string Class, string Division, string FeeType, string FeeStatus);
        public FileStreamResult GetReport(string ReportName, DataSource Data, List<JSReportParameter> Para);
        FileStreamResult GetReport(DataSource Data);

    }
}
