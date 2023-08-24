using BoldReports.Web.ReportViewer;
using BoldReports.Writer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OrisonFeeAnalysis.Logics.Contract.BoldReport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Controller.BoldReport
{
    [Route("api/{controller}/{action}/{id?}")]
    public class ReportViewerController : ControllerBase, IReportController
    {
        private IMemoryCache _cache;
        private IWebHostEnvironment _hostingEnvironment;
        public static Dictionary<string, Object> jsonResult = null;
        public static IBoldReportManager _repository;

        public ReportViewerController(IMemoryCache memoryCache, IWebHostEnvironment hostingEnvironment, IBoldReportManager repository)
        {
            _cache = memoryCache;
            _hostingEnvironment = hostingEnvironment;
            _repository = repository;
        }
        [ActionName("GetResource")]
        [AcceptVerbs("GET")]
        public object GetResource(ReportResource resource)
        {
            return ReportHelper.GetResource(resource, this, _cache);
        }
        public void OnInitReportOptions(ReportViewerOptions reportOption)
        {
            string Accyear = null, DateFrom = null, DateTo = null, branchID = null, Description = null, UserName = null;
            string basePath = _hostingEnvironment.WebRootPath;
            reportOption.ReportModel.ProcessingMode = BoldReports.Web.ReportViewer.ProcessingMode.Local;
            FileStream inputStream = new FileStream(basePath + @"\Reports\" + reportOption.ReportModel.ReportPath + ".rdl", FileMode.Open, FileAccess.Read);
            MemoryStream reportStream = new MemoryStream();
            inputStream.CopyTo(reportStream);
            reportStream.Position = 0;
            inputStream.Close();
            reportOption.ReportModel.Stream = reportStream;
            foreach (var i in jsonResult)
            {
                if (i.Key == "parameters")
                {
                    Accyear = i.Value.ToString().Split(",")[1].Split(":")[1].Split("\"")[1];
                    DateFrom = i.Value.ToString().Split(",")[3].Split(":")[1].Split("\"")[1];
                    DateTo = i.Value.ToString().Split(",")[5].Split(":")[1].Split("\"")[1];
                    branchID = i.Value.ToString().Split(",")[7].Split(":")[1].Split("\"")[1];
                    Description = i.Value.ToString().Split(",")[9].Split(":")[1].Split("\"")[1];
                    UserName = i.Value.ToString().Split(",")[11].Split(":")[1].Split("\"")[1];
                }
            }
            if (reportOption.ReportModel.ReportPath == "collection summary")
            {
                reportOption.ReportModel.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.GetAnalysisData("GetGridData", Accyear, Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Description, UserName).Result.ToList() });
            }
            if (reportOption.ReportModel.ReportPath == "ONE DAY COLLECTION DETAILS")
            {
                reportOption.ReportModel.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.GetAnalysisData("GetGridDataDetails", Accyear, Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Description, UserName).Result.ToList() });
            }
            if (reportOption.ReportModel.ReportPath == "ONE DAY COLLECTION DETAILS EXAM FEE")
            {
                reportOption.ReportModel.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.GetAnalysisData("GetGridDataDetails", Accyear, Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Description, UserName).Result.ToList() });
            }
            if (reportOption.ReportModel.ReportPath == "collectiondetails")
            {
                reportOption.ReportModel.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.GetAnalysisData("CollectionDetails", Accyear, Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Description, UserName).Result.ToList() });
            }
            if (reportOption.ReportModel.ReportPath == "DashBoard")
            {
                reportOption.ReportModel.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.GetAnalysisData("DashBoard", Accyear, Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Description, UserName).Result.ToList() });
            }
            if (reportOption.ReportModel.ReportPath == "collctionsummerytilldate")
            {
                reportOption.ReportModel.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.GetAnalysisData("SummaryTillDate", Accyear, Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Description, UserName).Result.ToList() });
            }
        }

        [HttpGet]
        public IActionResult Export(string Parameter)
        {
            string ReportName = Parameter.Split(",")[0].Split(":")[1].Split("\"")[1];
            string basePath = _hostingEnvironment.WebRootPath;

            FileStream inputStream = new FileStream(basePath + @"\Reports\" + ReportName + ".rdl", FileMode.Open, FileAccess.Read);

            MemoryStream reportStream = new MemoryStream();
            inputStream.CopyTo(reportStream);
            reportStream.Position = 0;
            inputStream.Close();
            BoldReports.Writer.ReportWriter writer = new BoldReports.Writer.ReportWriter(reportStream);
            writer.ReportProcessingMode = BoldReports.Writer.ProcessingMode.Local;
            writer.DataSources.Clear();

            if (ReportName == "collctionsummerytilldate")
            {
                string Accyear = Parameter.Split(",")[1].Split(":")[1].Split("\"")[1];
                string DateFrom = Parameter.Split(",")[2].Split(":")[1].Split("\"")[1];
                string DateTo = Parameter.Split(",")[3].Split(":")[1].Split("\"")[1].Split("T")[0];
                string branchID = Parameter.Split(",")[4].Split(":")[1].Split("\"")[1];
                string Description = Parameter.Split(",")[5].Split(":")[1].Split("\"")[1];
                string UserName = Parameter.Split(",")[6].Split(":")[1].Split("\"")[1];
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.GetAnalysisData(Convert.ToString("SummaryTillDate"), Convert.ToString(Accyear), Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Convert.ToString(Description), Convert.ToString(UserName)).Result.ToList() });
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "Exemption", Value = _repository.GetAnalysisData(Convert.ToString("ExemptionStudentCount"), Convert.ToString(Accyear), Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Convert.ToString(Description), Convert.ToString(UserName)).Result.ToList() });
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "NewStudent", Value = _repository.GetAnalysisData(Convert.ToString("NewStudentCount"), Convert.ToString(Accyear), Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Convert.ToString(Description), Convert.ToString(UserName)).Result.ToList() });
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "StudentCount", Value = _repository.GetAnalysisData(Convert.ToString("StudentCount"), Convert.ToString(Accyear), Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Convert.ToString(Description), Convert.ToString(UserName)).Result.ToList() });
            }
            if (ReportName == "DashBoard")
            {
                string Accyear = Parameter.Split(",")[1].Split(":")[1].Split("\"")[1];
                string DateFrom = Parameter.Split(",")[2].Split(":")[1].Split("\"")[1].Split("T")[0];
                string DateTo = Parameter.Split(",")[3].Split(":")[1].Split("\"")[1].Split("T")[0];
                string branchID = Parameter.Split(",")[4].Split(":")[1].Split("\"")[1];
                string Description = Parameter.Split(",")[5].Split(":")[1].Split("\"")[1];
                string UserName = Parameter.Split(",")[6].Split(":")[1].Split("\"")[1];
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.GetAnalysisData(Convert.ToString("DashBoard"), Convert.ToString(Accyear), Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Convert.ToString(Description), Convert.ToString(UserName)).Result.ToList() });
            }
            if (ReportName == "collection summary")
            {
                string Accyear = Parameter.Split(",")[1].Split(":")[1].Split("\"")[1];
                string DateFrom = Parameter.Split(",")[2].Split(":")[1].Split("\"")[1].Split("T")[0];
                string DateTo = Parameter.Split(",")[3].Split(":")[1].Split("\"")[1].Split("T")[0];
                string branchID = Parameter.Split(",")[4].Split(":")[1].Split("\"")[1];
                string Description = Parameter.Split(",")[5].Split(":")[1].Split("\"")[1];
                string UserName = Parameter.Split(",")[6].Split(":")[1].Split("\"")[1];
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.GetAnalysisData(Convert.ToString("GetGridData"), Convert.ToString(Accyear), Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Convert.ToString(Description), Convert.ToString(UserName)).Result.ToList() });
            }
            if (ReportName == "ONE DAY COLLECTION DETAILS" || ReportName == "ONE DAY COLLECTION DETAILS Reciept Wise")
            {
                string Accyear = Parameter.Split(",")[1].Split(":")[1].Split("\"")[1];
                string DateFrom = Parameter.Split(",")[2].Split(":")[1].Split("\"")[1].Split("T")[0];
                string DateTo = Parameter.Split(",")[3].Split(":")[1].Split("\"")[1].Split("T")[0];
                string branchID = Parameter.Split(",")[4].Split(":")[1].Split("\"")[1];
                string Description = Parameter.Split(",")[5].Split(":")[1].Split("\"")[1];
                string UserName = Parameter.Split(",")[6].Split(":")[1].Split("\"")[1];
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.GetAnalysisData(Convert.ToString("GetGridDataDetails"), Convert.ToString(Accyear), Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Convert.ToString(Description), Convert.ToString(UserName)).Result.ToList() });
            }
            if (ReportName == "usercollectionsummary")
            {
                string Accyear = Parameter.Split(",")[1].Split(":")[1].Split("\"")[1];
                string DateFrom = Parameter.Split(",")[2].Split(":")[1].Split("\"")[1].Split("T")[0];
                string DateTo = Parameter.Split(",")[3].Split(":")[1].Split("\"")[1].Split("T")[0];
                string branchID = Parameter.Split(",")[4].Split(":")[1].Split("\"")[1];
                string Description = Parameter.Split(",")[5].Split(":")[1].Split("\"")[1];
                string UserName = Parameter.Split(",")[6].Split(":")[1].Split("\"")[1];
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.GetAnalysisData(Convert.ToString("GetUserWiseSummary"), Convert.ToString(Accyear), Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Convert.ToString(Description), Convert.ToString(UserName)).Result.ToList() });
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "NOS", Value = _repository.GetAnalysisData(Convert.ToString("GetGridDataCount"), Convert.ToString(Accyear), Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Convert.ToString(Description), Convert.ToString(UserName)).Result.ToList() });
            }
            if (ReportName == "userwise collection details")
            {
                string Accyear = Parameter.Split(",")[1].Split(":")[1].Split("\"")[1];
                string DateFrom = Parameter.Split(",")[2].Split(":")[1].Split("\"")[1].Split("T")[0];
                string DateTo = Parameter.Split(",")[3].Split(":")[1].Split("\"")[1].Split("T")[0];
                string branchID = Parameter.Split(",")[4].Split(":")[1].Split("\"")[1];
                string Description = Parameter.Split(",")[5].Split(":")[1].Split("\"")[1];
                string UserName = Parameter.Split(",")[6].Split(":")[1].Split("\"")[1];
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.GetAnalysisData(Convert.ToString("UserWiseCollectionDetails"), Convert.ToString(Accyear), Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Convert.ToString(Description), Convert.ToString(UserName)).Result.ToList() });
            }
            if (ReportName == "re-registration fee")
            {
                string Accyear = Parameter.Split(",")[1].Split(":")[1].Split("\"")[1];
                string DateFrom = Parameter.Split(",")[2].Split(":")[1].Split("\"")[1].Split("T")[0];
                string DateTo = Parameter.Split(",")[3].Split(":")[1].Split("\"")[1].Split("T")[0];
                string branchID = Parameter.Split(",")[4].Split(":")[1].Split("\"")[1];
                string Description = Parameter.Split(",")[5].Split(":")[1].Split("\"")[1];
                string UserName = Parameter.Split(",")[6].Split(":")[1].Split("\"")[1];
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.GetAnalysisData(Convert.ToString("GetGridClasswiseReReg"), Convert.ToString(Accyear), Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Convert.ToString(Description), Convert.ToString(UserName)).Result.ToList() });
            }
            if (ReportName == "classwise fee Tutionfee")
            {
                string Accyear = Parameter.Split(",")[1].Split(":")[1].Split("\"")[1];
                string DateFrom = Parameter.Split(",")[2].Split(":")[1].Split("\"")[1].Split("T")[0];
                string DateTo = Parameter.Split(",")[3].Split(":")[1].Split("\"")[1].Split("T")[0];
                string branchID = Parameter.Split(",")[4].Split(":")[1].Split("\"")[1];
                string Description = Parameter.Split(",")[5].Split(":")[1].Split("\"")[1];
                string UserName = Parameter.Split(",")[6].Split(":")[1].Split("\"")[1];
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.GetAnalysisData(Convert.ToString("GetGridClasswiseTuition"), Convert.ToString(Accyear), Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Convert.ToString(Description), Convert.ToString(UserName)).Result.ToList() });
            }
            if (ReportName == "Paid Not paid Summary")
            {
                string Accyear = Parameter.Split(",")[1].Split(":")[1].Split("\"")[1];
                string DateFrom = Parameter.Split(",")[2].Split(":")[1].Split("\"")[1].Split("T")[0];
                string DateTo = Parameter.Split(",")[3].Split(":")[1].Split("\"")[1].Split("T")[0];
                string branchID = Parameter.Split(",")[4].Split(":")[1].Split("\"")[1];
                string Description = Parameter.Split(",")[5].Split(":")[1].Split("\"")[1];
                string UserName = Parameter.Split(",")[6].Split(":")[1].Split("\"")[1];
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.GetAnalysisData(Convert.ToString("GetPaidSummary"), Convert.ToString(Accyear), Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Convert.ToString(Description), Convert.ToString(UserName)).Result.ToList() });
            }
            if (ReportName == "collectiondetails")
            {
                string Accyear = Parameter.Split(",")[1].Split(":")[1].Split("\"")[1];
                string DateFrom = Parameter.Split(",")[2].Split(":")[1].Split("\"")[1].Split("T")[0];
                string DateTo = Parameter.Split(",")[3].Split(":")[1].Split("\"")[1].Split("T")[0];
                string branchID = Parameter.Split(",")[4].Split(":")[1].Split("\"")[1];
                string Description = Parameter.Split(",")[5].Split(":")[1].Split("\"")[1];
                string UserName = Parameter.Split(",")[6].Split(":")[1].Split("\"")[1];
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.GetAnalysisData(Convert.ToString("CollectionDetails"), Convert.ToString(Accyear), Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Convert.ToString(Description), Convert.ToString(UserName)).Result.ToList() });
            }

            if (ReportName == "FeeNotPaid" || ReportName == "FeeNotPaid Class Wise")
            {
                string Accyear = Parameter.Split(",")[1].Split(":")[1].Split("\"")[1];
                string DateFrom = Parameter.Split(",")[2].Split(":")[1].Split("\"")[1].Split("T")[0];
                string DateTo = Parameter.Split(",")[3].Split(":")[1].Split("\"")[1].Split("T")[0];
                string branchID = Parameter.Split(",")[4].Split(":")[1].Split("\"")[1];
                string Description = Parameter.Split(",")[5].Split(":")[1].Split("\"")[1];
                string UserName = Parameter.Split(",")[6].Split(":")[1].Split("\"")[1];
                string Class = Parameter.Split(",")[7].Split(":")[1].Split("\"")[1];
                string Division = Parameter.Split(",")[8].Split(":")[1].Split("\"")[1];
                string FeeType = Parameter.Split(",")[9].Split(":")[1].Split("\"")[1];
                string FeeStatus = Parameter.Split(",")[10].Split(":")[1].Split("\"")[1];
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.FeePaidNotPaid(Convert.ToString("GetPaidDetails"), Convert.ToString(Accyear), Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo), Convert.ToInt32(branchID), Convert.ToString(Description), Convert.ToString(UserName), Class, Division, FeeType, FeeStatus).Result.ToList() });
            }

            string fileName = ReportName + ".pdf";
            MemoryStream memoryStream = new MemoryStream();
            WriterFormat format = WriterFormat.PDF;
            writer.Save(memoryStream, format);

            memoryStream.Position = 0;
            FileStreamResult fileStreamResult = new FileStreamResult(memoryStream, "application/" + "pdf");
            fileStreamResult.FileDownloadName = fileName;
            return fileStreamResult;
        }
        public void OnReportLoaded(ReportViewerOptions reportOption)
        {

        }

        [HttpPost]
        public object PostFormReportAction()
        {
            return ReportHelper.ProcessReport(null, this, _cache);
        }

        [HttpPost]
        public object PostReportAction([FromBody] Dictionary<string, object> jsonArray)
        {
            jsonResult = jsonArray;
            return ReportHelper.ProcessReport(jsonArray, this, this._cache);
        }
    }
}
