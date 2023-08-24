namespace OrisonFeeAnalysis.Entities.Financial.Main
{
    public class dtsFinancial
    {
        public dtfinVoucher finVoucher { get; set; }
        public dtfinVEntry[] finVEntry { get; set; }
        public dtfinVoucherAllocation[] finVAllocation { get; set; }
        public Cheque[] finCheques { get; set; }

    }
}
