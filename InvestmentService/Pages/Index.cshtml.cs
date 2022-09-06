using InvestmentService.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvestmentService.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICustomerInfoRepository _customerInfoRepository;
        private readonly IConsultantInfoRepository _consultantInfoRepository;
        private readonly IDiscretionaryRuleRepository _discretionaryRuleRepository;

        public IndexModel(
            ILogger<IndexModel> logger,
            ICustomerInfoRepository customerInfoRepository,
            IConsultantInfoRepository consultantInfoRepository,
            IDiscretionaryRuleRepository discretionaryRuleRepository
        )
        {
            _logger = logger;
            _customerInfoRepository = customerInfoRepository;
            _consultantInfoRepository = consultantInfoRepository;
            _discretionaryRuleRepository = discretionaryRuleRepository;
        }

        public async Task OnGet()
        {
            var x = await _customerInfoRepository.GetAsync();
            var y = await _consultantInfoRepository.GetAsync();
            var z = await _discretionaryRuleRepository.GetAsync();
        }
    }
}