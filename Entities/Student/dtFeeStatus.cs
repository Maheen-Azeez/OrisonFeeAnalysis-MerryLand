using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Entities.Student
{
    public class dtFeeStatus
    {
        [Key]
        public int ID { get; set; }
        public Boolean Allocated { get; set; }
        public string FeeStatus { get; set; }
        public string VNo { get; set; }
        public int VType { get; set; }
        public int VNoInt { get; set; }
        public string RefNo { get; set; }
        public DateTime VDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime DueDate { get; set; }
        public string VoucherAgainst { get; set; }
        public string CommonNarration { get; set; }
        public int BranchID { get; set; }

        public int AccountID { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidDate { get; set; }
    }
}
