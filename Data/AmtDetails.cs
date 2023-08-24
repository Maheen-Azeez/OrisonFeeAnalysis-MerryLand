using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Data
{
    public class AmtDetails
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public long TrnID { get; set; }
        public long ID { get; set; }

        public int? CardType { get; set; }
        public decimal? Commission { get; set; }
        public string ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public int ClrDays { get; set; }

        public int BankID { get; set; }
        public string BankName { get; set; }
        public string Status { get; set; }

        public int PartyID { get; set; }
        public string PartyName { get; set; }

        public string Description2 { get; set; }
        public string State { get; set; }
    }
}
