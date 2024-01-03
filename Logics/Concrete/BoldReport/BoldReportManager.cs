using BoldReports.Writer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OrisonFeeAnalysis.Data.BoldReport;
using OrisonFeeAnalysis.Entities;
using OrisonFeeAnalysis.Logics.Contract.BoldReport;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Logics.Concrete.BoldReport
{
    public class BoldReportManager : IBoldReportManager
    {
        private IWebHostEnvironment _hostingEnvironment;
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;
        public BoldReportManager(IWebHostEnvironment hostingEnvironment, HttpClient httpClient, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<List<ExpandoObject>> GetRegistrationByID(long id)
        {
            List<ExpandoObject> Result = new List<ExpandoObject>();
            var job = await httpClient.GetJsonAsync<List<object>>(BaseUrl + "BoldReport/GetRegistrationByID?ID=" + id);
            foreach (var dt in job)
                Result.Add(JsonConvert.DeserializeObject<ExpandoObject>(dt.ToString()));
            return Result;
        }
        public async Task<List<ReceiptPrint>> GetFeeRecieptByID(long VID, int ONO, string AccYear)
        {
            try
            {
                var job = await httpClient.GetJsonAsync<List<ReceiptPrint>>(BaseUrl + "BoldReport/GetFeeRecieptByID?VID=" + VID + "&AccYear=" + AccYear + "&ONO=" + ONO);
                return job;
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }
        public async Task<List<ReceiptPrint>> GetFeeVtype(long VID)
        {
            var job = await httpClient.GetJsonAsync<List<ReceiptPrint>>(BaseUrl + "BoldReport/GetVtype?VID=" + VID);
            return job;
        }
        public async Task<List<ExpandoObject>> GetAnalysisData(string Criteria,string Accyear, DateTime DateFrom, DateTime DateTo, int branchID, string Description, string UserName)
        {
            try
            {
                List<ExpandoObject> Result = new List<ExpandoObject>();
                var job = await httpClient.GetJsonAsync<List<object>>(BaseUrl + "BoldReport/GetAnalysisData?Criteria=" + Criteria + "&Accyear=" + Accyear + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo + "&branchID=" + branchID + "&Description=" + Description + "&UserName=" + UserName);
                foreach (var dt in job)
                    Result.Add(JsonConvert.DeserializeObject<ExpandoObject>(dt.ToString()));
                return Result;
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
        public async Task<List<ExpandoObject>> GetAnalysisData(string Criteria, string Accyear, string DateFrom, string DateTo, int branchID, string Description, string UserName)
        {
            try
            {
                List<ExpandoObject> Result = new List<ExpandoObject>();
                var job = await httpClient.GetJsonAsync<List<object>>(BaseUrl + "BoldReport/GetAnalysisData?Criteria=" + Criteria + "&Accyear=" + Accyear + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo + "&branchID=" + branchID + "&Description=" + Description + "&UserName=" + UserName);
                foreach (var dt in job)
                    Result.Add(JsonConvert.DeserializeObject<ExpandoObject>(dt.ToString()));
                return Result;
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public async Task<List<ExpandoObject>> FeePaidNotPaid(string Criteria,string Accyear, DateTime DateFrom, DateTime DateTo, int branchID, string Description, string UserName, string Class, string Division, string FeeType, string FeeStatus)
        {
            List<ExpandoObject> Result = new List<ExpandoObject>();
            var job = await httpClient.GetJsonAsync<List<object>>(BaseUrl + "BoldReport/PaidNotPaid?Criteria=" + Criteria + "&Accyear=" + Accyear + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo + "&branchID=" + branchID + "&Description=" + Description + "&UserName=" + UserName + "&Class=" + Class + "&Division=" + Division + "&FeeType=" + FeeType + "&FeeStatus=" + FeeStatus);
            foreach (var dt in job)
                Result.Add(JsonConvert.DeserializeObject<ExpandoObject>(dt.ToString()));
            return Result;
        }

        public FileStreamResult GetReport(string ReportName, DataSource Data, List<JSReportParameter> Para)
        {
            FileStream inputStream = new FileStream(_hostingEnvironment.WebRootPath + @"\Reports\" + ReportName + ".rdl", FileMode.Open, FileAccess.Read);
            MemoryStream reportStream = new MemoryStream();
            inputStream.CopyTo(reportStream);
            reportStream.Position = 0;
            inputStream.Close();
            BoldReports.Writer.ReportWriter writer = new BoldReports.Writer.ReportWriter(reportStream);
            writer.ReportProcessingMode = BoldReports.Writer.ProcessingMode.Local;
            writer.DataSources.Clear();

            if (ReportName == "Collection Summary TillDate")
            {
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = Data.DataSet1.ToList() });
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "Exemption", Value = Data.DataSet2.ToList() });
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "NewStudent", Value = Data.DataSet3.ToList() });
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "StudentCount", Value = Data.DataSet4.ToList() });
                //writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet2", Value = Data.DataSet5.ToList() });
            }
            else if (ReportName == "User Collection Summary")
            {
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = Data.DataSet1.ToList() });
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "NOS", Value = Data.DataSet2.ToList() });
            }
            else
            {
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = Data.DataSet1.ToList() });
            }
            if(ReportName== "Vacancy Summary")
            {
                List<BoldReports.Web.ReportParameter> userParameters = new List<BoldReports.Web.ReportParameter>
                {
                    new BoldReports.Web.ReportParameter()
                    {
                        Name = "TvacancyMale",
                        Values = new List<string>() { Para[0].Values[0].ToString() }
                    },
                    new BoldReports.Web.ReportParameter()
                    {
                        Name = "Tvacancyfemale",
                        Values = new List<string>() { Para[1].Values[0].ToString() }
                    }, 
                    new BoldReports.Web.ReportParameter()
                    {
                        Name = "Accyear",
                        Values = new List<string>() { Para[2].Values[0].ToString() }
                    }
                };
                writer.SetParameters(userParameters);

            }

            if (ReportName == "Collection Summary" || ReportName== "ONE DAY COLLECTION DETAILS EXAM FEE" || ReportName == "ONE DAY COLLECTION DETAILS" || ReportName == "ONE DAY COLLECTION DETAILS Reciept Wise"
                || ReportName == "Collction Summary TillDate" || ReportName == "User Collection Summary" || ReportName == "Collection Details"
                || ReportName == "Re-Registration Fee" || ReportName == "DashBoard")
            {
                List<BoldReports.Web.ReportParameter> userParameters = new List<BoldReports.Web.ReportParameter>
                {
                    new BoldReports.Web.ReportParameter()
                    {
                        Name = "SDate",
                        Values = new List<string>() { Para[0].Values[0].ToString() }
                    },
                    new BoldReports.Web.ReportParameter()
                    {
                        Name = "EDate",
                        Values = new List<string>() { Para[1].Values[0].ToString() }
                    }
                };
                if(ReportName == "Re-Registration Fee")
                {
                    writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet2", Value = Data.DataSet2.ToList() });
                    userParameters.Add(new BoldReports.Web.ReportParameter() { Name = "Accyear", Values = new List<string>() { Para[2].Values[0].ToString() } });
                }
                writer.SetParameters(userParameters);
            }
            else if(ReportName == "Classwise Tutionfee")
            {
                List<BoldReports.Web.ReportParameter> userParameters = new List<BoldReports.Web.ReportParameter>
                {
                    new BoldReports.Web.ReportParameter()
                    {
                        Name = "DateFrom",
                        Values = new List<string>() { Para[0].Values[0].ToString() }
                    },
                    new BoldReports.Web.ReportParameter()
                    {
                        Name = "DateTo",
                        Values = new List<string>() { Para[1].Values[0].ToString() }
                    }
                };
                writer.SetParameters(userParameters);

            }
            if (ReportName== "FEE PAID AND NOT PAID DETAILS" || ReportName== "FeeNotPaid Class Wise")
            {
                List<BoldReports.Web.ReportParameter> userParameters = new List<BoldReports.Web.ReportParameter>
                {
                    new BoldReports.Web.ReportParameter()
                    {
                        Name = "PaidStatus",
                        Values = new List<string>() { Para[0].Values[0].ToString() }
                    }
                };
                writer.SetParameters(userParameters);
            }
            if(ReportName == "Classwise Summary")
            {
                List<BoldReports.Web.ReportParameter> userParameters = new List<BoldReports.Web.ReportParameter>
                {
                    new BoldReports.Web.ReportParameter()
                    {
                        Name = "FeeType",
                        Values = new List<string>() { Para[0].Values[0].ToString() }
                    },
                    new BoldReports.Web.ReportParameter()
                    {
                        Name = "AccYear",
                        Values = new List<string>() { Para[1].Values[0].ToString() }
                    }
                };
                writer.SetParameters(userParameters);
            }
            if (ReportName == "Student Fee Receipt")
            {
                List<BoldReports.Web.ReportParameter> userParameters = new List<BoldReports.Web.ReportParameter>
                {
                    new BoldReports.Web.ReportParameter()
                    {
                        Name = "AcademicYear",
                        Values = new List<string>() { Para[0].Values[0].ToString() }
                    }
                    
                };
                writer.SetParameters(userParameters);
            }



            string fileName = ReportName + ".pdf";
            WriterFormat format = WriterFormat.PDF;
            string type = "pdf";

            MemoryStream memoryStream = new MemoryStream();
            writer.Save(memoryStream, format);

            memoryStream.Position = 0;
            FileStreamResult fileStreamResult = new FileStreamResult(memoryStream, "application/" + type);
            fileStreamResult.FileDownloadName = fileName;
            return fileStreamResult;
        }
    }
}
