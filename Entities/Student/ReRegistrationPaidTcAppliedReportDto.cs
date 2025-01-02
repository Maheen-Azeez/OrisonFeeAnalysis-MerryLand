using System;

namespace OrisonFeeAnalysis.Entities.Student
{
    public class ReRegistrationPaidTcAppliedReportDto
    {
        public int AccountID { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string Class { get; set; }
        public string Division { get; set; }
        public string PNo { get; set; }
        public string SubStatus { get; set; }
        public DateTime? RDate { get; set; }
        public string PaidStatus { get; set; }
        public string FeeType { get; set; }
        public DateTime? TDate { get; set; }
    }
}
