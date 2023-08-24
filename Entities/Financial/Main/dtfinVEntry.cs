using System;

namespace OrisonFeeAnalysis.Entities.Financial.Main
{
    public class dtfinVEntry
    {
        public long ID { get; set; }
        public long VID { get; set; }
        public decimal? SlNo { get; set; }
        public string RowType { get; set; }
        public bool? VisibleonPrint { get; set; }
        public bool? Reconciled { get; set; }
        public bool? Active { get; set; }
        public string Action { get; set; }
        public long? UserTrackID { get; set; }
        public long? RefID { get; set; }
        public int AccountID { get; set; }
        public string TranType { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string AccountHead { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public int ChequeID { get; set; }
        public string ChequeNo { get; set; }
        public string CardType { get; set; }
        public decimal? Commission { get; set; }
        public DateTime? Date { get; set; }
        public string ClrDays { get; set; }
        public int BankID { get; set; }
        public string BankName { get; set; }
        public string Status { get; set; }
        public int PartyID { get; set; }
        public string Card { get; set; }
        public string Deposit_To { get; set; }
        public int VType { get; set; }
        public int BranchID { get; set; }
        public string InvNo { get; set; }
        public DateTime? InvDate { get; set; }
        public string TRNNo { get; set; }
        public string SupName { get; set; }
        public decimal? VAT { get; set; }
        public decimal? Taxable { get; set; }
        public decimal? Amount { get; set; }
        public string RowState { get; set; }

    }
}
