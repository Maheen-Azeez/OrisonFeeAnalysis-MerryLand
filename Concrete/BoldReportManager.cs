using BoldReports.Writer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OrisonFeeAnalysis.Contract;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using OrisonFeeAnalysis.Entities.Student;
using OrisonFeeAnalysis.Entities;

namespace OrisonFeeAnalysis.Concrete
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
        public async Task<List<ExpandoObject>> GetFeeReciept(long id,string accyear)
        {
            List<ExpandoObject> Result = new List<ExpandoObject>();
            var job = await httpClient.GetJsonAsync<List<object>>(BaseUrl + "BoldReport/GetFeeReciept?VID=" + id + "&accyear=" + accyear);
            foreach (var dt in job)
                Result.Add(JsonConvert.DeserializeObject<ExpandoObject>(dt.ToString()));
            return Result;
        }
        public FileStreamResult GetReport(string ReportName, DataSource Data)
        {
            FileStream inputStream = new FileStream(_hostingEnvironment.WebRootPath + @"\Reports\" + ReportName + ".rdl", FileMode.Open, FileAccess.Read);
            MemoryStream reportStream = new MemoryStream();
            inputStream.CopyTo(reportStream);
            reportStream.Position = 0;
            inputStream.Close();
            BoldReports.Writer.ReportWriter writer = new BoldReports.Writer.ReportWriter(reportStream);
            writer.ReportProcessingMode = BoldReports.Writer.ProcessingMode.Local;
            writer.DataSources.Clear();

            if (ReportName == "Fee Receipt" || ReportName == "Fee Receipt Register")
            {
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = Data.DataSet1.ToList() });
            }
            else if (ReportName == "MerryLandStudentRegister")
            {
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = Data.DataSet1.ToList() });
            }
            else if (ReportName == "CAIE Subject Report")
            {
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = Data.DataSet1.ToList() });
            }
            else if (ReportName == "OptionalRegisterReport-May-Jun")
            {
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = Data.DataSet1.ToList() });
            }
            else if (ReportName == "OptionalRegisterReport-Oct-Nov")
            {
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = Data.DataSet1.ToList() });
            }
            else
            {
                try
                {
                    writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = Data.DataSet1.ToList() });

                }
                catch (Exception e)
                {

                    throw e;
                }
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
        public async Task<FileStreamResult> GetDocument(string ReportName, long VoucherID,string accyear)
        {
            FileStream inputStream = new FileStream(_hostingEnvironment.WebRootPath + @"\Reports\" + ReportName + ".rdl", FileMode.Open, FileAccess.Read);
            MemoryStream reportStream = new MemoryStream();
            inputStream.CopyTo(reportStream);
            reportStream.Position = 0;
            inputStream.Close();
            BoldReports.Writer.ReportWriter writer = new BoldReports.Writer.ReportWriter(reportStream);
            writer.ReportProcessingMode = BoldReports.Writer.ProcessingMode.Local;
            writer.DataSources.Clear();

            if (ReportName == "Fee Receipt" || ReportName == "Fee Receipt Register")
            {
                try
                {
                    //var DataSource = await GetFeeReciept(VoucherID,accyear);
                    var Data = await GetFeeRecieptByID(VoucherID, 0, accyear);
                    var VTypes = await GetFeeVtype(VoucherID);
                    if (Data.Count > 0 && VTypes.Count > 0)
                    {
                        Data[0].TranType = VTypes[0].TranType;
                        Data[0].debit = VTypes[0].debit;
                        Data[0].ChequeNo = VTypes[0].ChequeNo;
                        Data[0].ChequeDate = VTypes[0].ChequeDate;
                        Data[0].BankName = VTypes[0].BankName;
                        if (VTypes.Count > 1)
                        {
                            if (Data.Count == 1)
                            {
                                Data.Add(new ReceiptPrint());
                                Data[0].AccountName = Data[0].AccountName;
                                Data[0].VEID = Data[0].VEID;
                                Data[0].ONO = Data[0].ONO;
                            }
                            Data[1].TranType = VTypes[1].TranType;
                            Data[1].debit = VTypes[1].debit;
                            Data[1].ChequeNo = VTypes[1].ChequeNo;
                            Data[1].ChequeDate = VTypes[1].ChequeDate;
                            Data[1].BankName = VTypes[1].BankName;
                        }
                    }
                    DataSource dt = new DataSource();
                    dt.DataSet1 = new List<ExpandoObject>();
                    dt.DataSet1 = JsonConvert.DeserializeObject<List<ExpandoObject>>(JsonConvert.SerializeObject(Data));
                    writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = dt.DataSet1.ToList() });
                }
                catch (Exception e)
                {

                    throw e;
                }
                
            }
            else if(ReportName == "Exam Fee Receipt")
            {
                var Data = await GetFeeRecieptByID(VoucherID, 0, accyear);
                var Data2 = await GetFeeRecieptByID(VoucherID, 1, accyear);
                var VTypes = await GetFeeVtype(VoucherID);

                DataSource dt = new DataSource();
                dt.DataSet1 = new List<ExpandoObject>();
                foreach (var ds in VTypes)
                {
                    foreach (var d in Data)
                    {
                        if (ds.TranType == "Cash")
                            d.TranType = d.TranType + ds.TranType + ", ";
                        else if (ds.TranType == "Cheque")
                            d.TranType = d.TranType + ds.TranType + "(" + ds.ChequeNo + "/ " + ds.ChequeDate.Value.ToString("dd-MM-yyyy") + "/ " + ds.BankName + "), ";
                        else if (ds.TranType == "TT")
                            d.TranType = d.TranType + ds.TranType + "(" + ds.ChequeNo + "/ " + ds.ChequeDate.Value.ToString("dd-MM-yyyy") + "), ";
                    }
                    foreach (var d in Data2)
                    {
                        if (ds.TranType == "Cash")
                            d.TranType = d.TranType + ds.TranType + ", ";
                        else if (ds.TranType == "Cheque")
                            d.TranType = d.TranType + ds.TranType + "(" + ds.ChequeNo + "/ " + ds.ChequeDate.Value.ToString("dd-MM-yyyy") + "/ " + ds.BankName + "), ";
                        else if (ds.TranType == "TT")
                            d.TranType = d.TranType + ds.TranType + "(" + ds.ChequeNo + "/ " + ds.ChequeDate.Value.ToString("dd-MM-yyyy") + "), ";
                    }
                }
                dt.DataSet1 = new List<ExpandoObject>();
                dt.DataSet1.AddRange(JsonConvert.DeserializeObject<List<ExpandoObject>>(JsonConvert.SerializeObject(Data)));
                dt.DataSet1.AddRange(JsonConvert.DeserializeObject<List<ExpandoObject>>(JsonConvert.SerializeObject(Data2)));
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = dt.DataSet1.ToList() });


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
        public async Task<List<ReceiptPrint>> GetFeeRecieptByID(long VID, int ONO, string AccYear)
        {
            try
            {
                var job = await httpClient.GetJsonAsync<List<ReceiptPrint>>(BaseUrl + "BoldReport/GetFeeRecieptByID?VID=" + VID + "&AccYear=" + AccYear + "&ONO=" + ONO);
                return job;
            }
            catch (Exception E)
            {

                throw E;
            }            
        }
        public async Task<List<ReceiptPrint>> GetFeeVtype(long VID)
        {
            var job = await httpClient.GetJsonAsync<List<ReceiptPrint>>(BaseUrl + "BoldReport/GetVtype?VID=" + VID);
            return job;
        }
    }
}
