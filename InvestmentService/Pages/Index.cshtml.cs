using InvestmentService.DataAccess.Models;
using InvestmentService.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvestmentService.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConsultantInfoRepository _consultantInfoRepository;

        public IndexModel(
            ILogger<IndexModel> logger,
            IConsultantInfoRepository consultantInfoRepository
        )
        {
            _logger = logger;
            _consultantInfoRepository = consultantInfoRepository;
        }

        [BindProperty]
        public List<ConsultantInfo> ConsultantInfos { get; set; }
        [BindProperty]
        public int? SelectedConsultantInfoId { get; set; }
        [BindProperty]
        public int? SelectedCustomerInfoId { get; set; }

        public async Task OnGet()
        {
            var consultantInfos = await _consultantInfoRepository.GetAsync();
            ConsultantInfos = consultantInfos;
        }

        public async Task OnPostCustomer(int consultantInfoId)
        {
            var consultantInfos = await _consultantInfoRepository.GetAsync();
            ConsultantInfos = consultantInfos;
            SelectedConsultantInfoId = consultantInfoId;
        }

        public async Task OnPostDiscretionaryRule(int consultantInfoId, int customerInfoId)
        {
            var consultantInfos = await _consultantInfoRepository.GetAsync();
            ConsultantInfos = consultantInfos;
            SelectedConsultantInfoId = consultantInfoId;
            SelectedCustomerInfoId = customerInfoId;
        }
    }
}