using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Entities.Financial
{
    public class dtfinVoucherAllocation
    {
		[Key]
		public long ID { get; set; }
		public long VID { get; set; }
		public long VEID { get; set; }
		public decimal AccountID { get; set; }
		public decimal? ExchangeRate { get; set; }
		public int Sel { get; set; }
		public string VNo { get; set; }
		public string RefNo { get; set; }
		public DateTime Date { get; set; }
		public decimal? Amount { get; set; }
		public decimal? Paid { get; set; }
		public decimal? Receipt { get; set; }
		public decimal? Balance { get; set; }
		public string Description { get; set; }
		public string PartyName { get; set; }
		public string RowState { get; set; }
		public decimal? Cash { get; set; }
		public decimal? Cheque { get; set; }
		public decimal? TT { get; set; }

	}
}
