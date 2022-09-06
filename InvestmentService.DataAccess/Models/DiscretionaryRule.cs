using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentService.DataAccess.Models
{
    public class DiscretionaryRule
    {
        [Key]
        [Column("DiscretionaryRuleID")]
        public int DiscretionaryRuleId { get; set; }
        [Column("ConsultantID")]
        public int ConsultantId { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        public string? Rules { get; set; }
        public bool? CustomerBuy { get; set; }
        public bool? CustomerSell { get; set; }
        public bool? ConsultantBuy { get; set; }
        public bool? ConsultantSell { get; set; }

        [ForeignKey("ConsultantId")]
        public ConsultantInfo ConsultantInfo { get; set; } = null!;
        [ForeignKey("CustomerId")]
        public CustomerInfo CustomerInfo { get; set; } = null!;
    }
}
