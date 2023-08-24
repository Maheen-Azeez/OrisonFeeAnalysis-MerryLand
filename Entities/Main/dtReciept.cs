using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Entities.Main
{
    public class dtReciept
    {
        public int ID { get; set; }
        public string VID { get; set; }
        
        public string VEID { get; set; }
        public string ChequeNo { get; set; }
        public DateTime ChequeDate { get; set; }
        public DateTime VDate { get; set; }
        public string VNO { get; set; }
        public string RefNo { get; set; }
        public string CreatedUser { get; set; }
        public DateTime PostedDate { get; set; }
        public string PostedVID { get; set; }
        public string PostedVNo { get; set; }
        public string Status { get; set; }
        public int Debit { get; set; }
        public string Credit { get; set; }
        public string AccountID1 { get; set; }
        public string AccountName { get; set; }
        public string BankName { get; set; }
        public string PartyCode { get; set; }
        public string Party { get; set; }
        public string ContactNo { get; set; }
        public string Mobile2 { get; set; }
        public string Email { get; set; }
        public string PartyID { get; set; }
        public string AccountID { get; set; }
        public string PAccountCode { get; set; }
        public string PAccountName { get; set; }
        public string StStatus { get; set; }
        public string Class { get; set; }
        public string Division { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string SubStatus { get; set; }
        public string VoucherAgainst { get; set; }
        public string Remark { get; set; }
        public string ModifiedUser { get; set; }
    }
}
