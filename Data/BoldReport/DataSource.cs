using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Data.BoldReport
{
    public class DataSource
    {
        public List<ExpandoObject> DataSet1 { get; set; }
        public List<ExpandoObject> DataSet2 { get; set; }
        public List<ExpandoObject> DataSet3 { get; set; }
        public List<ExpandoObject> DataSet4 { get; set; }
        public List<ExpandoObject> DataSet5 { get; set; }
        public List<ExpandoObject> DataSet6 { get; set; }
        public List<ExpandoObject> DataSet7 { get; set; }
        public List<ExpandoObject> DataSet8 { get; set; }
        public List<ExpandoObject> DataSet9 { get; set; }
        public List<ExpandoObject> DataSet10 { get; set; }
        public List<JSReportParameter> Parameters { get; set; }
        public string ReportName { get; set; }
    }
}
