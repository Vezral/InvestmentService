using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentService.DataAccess.Models
{
    public class CustomerInfo
    {
        [Key]
        public int CustomerId { get; set; }
        public int? ConsultantId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailAddress { get; set; }

        [ForeignKey("ConsultantId")]
        public ConsultantInfo ConsultantInfo { get; set; } = null!;
        public List<DiscretionaryRule> DiscretionaryRules { get; set; } = null!;
    }
}
