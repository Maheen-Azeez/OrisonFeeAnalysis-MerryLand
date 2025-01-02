using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Entities.Main
{
    public class dtPaidandNotPaid
    {
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string Description { get; set; }
        public string subject { get; set; }
        public Decimal Amount { get; set; }
        public string SubjectName { get; set; }
        public string Gender { get; set; }

        public string Permobile { get; set; }
        public string ParentName { get; set; }
        public string Guardian { get; set; }

        public Decimal Fees { get; set; }
        public Decimal Paid { get; set; }
        public Decimal Balance { get; set; }
        public string Fee { get; set; }
        public string Class { get; set; }
        public string Division { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public int Term1Paid { get; set; }
        public int Term2Paid { get; set; }
        public int Term3Paid { get; set; }
        public int Term1NotPaid { get; set; }
        public int Term2NotPaid { get; set; }
        public int Term3NotPaid { get; set; }

        public string FatherMobile { get; set; }
        public string MotherMobile { get; set; }
        public string FatherEmail { get; set; }
        public string MotherEmail { get; set; }
        public string AdmissionStatus { get; set; }
        public int cnt { get; set; }
        public string PaidStatus { get; set; }
        public bool Blocked { get; set; }
        public bool Reregistered { get; set; }
        public int pno { get; set; }

    }
}
