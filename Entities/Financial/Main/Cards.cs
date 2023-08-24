using System.ComponentModel.DataAnnotations;

namespace OrisonFeeAnalysis.Entities.Financial.Main
{
    public class Cards
    {
        [Key]
        public long ID { get; set; }
        public string Description { get; set; }
        public decimal commission { get; set; }

    }
}
