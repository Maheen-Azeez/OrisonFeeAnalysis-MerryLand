using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Entities
{
    public class ReceiptPrint
    {
		public string vno { get; set; }
		public string BankName { get; set; }
		public long ID { get; set; }
		public long VID { get; set; }
		public long VEID { get; set; }
		public decimal? ExchangeRate { get; set; }
		public int Sel { get; set; }
		//public string VNo { get; set; }
		public string RefNo { get; set; }
		public int vnoint { get; set; }
		public DateTime? Date { get; set; }
		public DateTime? PostingDate { get; set; }
		public string AccountName { get; set; }
		public int AccountID { get; set; }
		public int ONO { get; set; }
		public string Accountcode { get; set; }
		public string Class { get; set; }
		public string Father { get; set; }
		public string Division { get; set; }
		public decimal? Paid { get; set; }
		public decimal? Receipt { get; set; }
		public decimal? Amount { get; set; }
		public decimal? Balance { get; set; }
		public string Description { get; set; }
		public decimal? VatPercent { get; set; }
		public decimal? VatAmount { get; set; }
		public string TRNNo { get; set; }
		public string TranType { get; set; }
		public decimal? debit { get; set; }
		public string ChequeNo { get; set; }
		public DateTime? ChequeDate { get; set; }
		public string Exam { get; set; }
		public string AcademicYear { get; set; }
	}
}
