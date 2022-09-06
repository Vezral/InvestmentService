using System.ComponentModel.DataAnnotations;

namespace InvestmentService.DataAccess.Models
{
    public class ConsultantInfo
    {
        [Key]
        public int ConsultantInfoId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? MobileNo { get; set; }
    }
}
