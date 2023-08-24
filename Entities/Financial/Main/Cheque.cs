using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Entities.Financial.Main
{
    public class Cheque
    {
        [Key]
        public long ID { get; set; }
        public long VEID { get; set; }
        public int? CardType { get; set; }
        public decimal? Commission { get; set; }
        public string ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public int ClrDays { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public int BankID { get; set; }
        public int AccountID { get; set; }
        public string BankName { get; set; }
        public string Status { get; set; }
        public decimal? IntAmount { get; set; }
        public int PartyID { get; set; }
        public string PartyName { get; set; }

        public string Trantype { get; set; }

        public string RowState { get; set; }
        public long CardID { get; set; }

        public int TranID { get; set; }

        public string CardDesc { get; set; }
        public decimal? SlNo { get; set; }


    }
}
