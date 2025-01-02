namespace OrisonFeeAnalysis.Entities.Student
{
    public class ReservedPaymentStatusSummarizedDTO
    {
        public string Class { get; set; }
        public int Total { get; set; }
        public int Paid { get; set; }
        public int NotPaid { get; set; }
    }
}
