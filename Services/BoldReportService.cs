using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Services
{
    public class BoldReportService
    {
        protected readonly ISessionStorageService _sessionStorage;
        private IWebHostEnvironment _hostingEnvironment;

        public BoldReportService(IWebHostEnvironment hostingEnvironment, ISessionStorageService SessionStorage)
        {
            _hostingEnvironment = hostingEnvironment;
            _sessionStorage = SessionStorage;

        }
        public async Task<FileStreamResult> GetDocument(string ReportName)
        {
            string basePath = _hostingEnvironment.WebRootPath;
            FileStream inputStream = new FileStream(basePath + @"\Reports\" + ReportName + ".rdl", FileMode.Open, FileAccess.Read);

            MemoryStream reportStream = new MemoryStream();
            inputStream.CopyTo(reportStream);
            reportStream.Position = 0;
            inputStream.Close();
            BoldReports.Writer.ReportWriter writer = new BoldReports.Writer.ReportWriter(reportStream);
            writer.ReportProcessingMode = BoldReports.Writer.ProcessingMode.Local;
            writer.DataSources.Clear();

            if (ReportName == "FeeNotPaid")
            {
                var sess = await _sessionStorage.GetItemAsync<string>("GridData");
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = JsonConvert.DeserializeObject<List<ExpandoObject>>(sess).ToList() });
            }

            string fileName = ReportName + ".pdf";
            BoldReports.Writer.WriterFormat format = BoldReports.Writer.WriterFormat.PDF;
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
