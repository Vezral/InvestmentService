using System.ComponentModel.DataAnnotations;

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
    }
}
