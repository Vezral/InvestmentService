using InvestmentService.DataAccess.Models;
using InvestmentService.DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace InvestmentService.DataAccess.Repositories
{
    public interface IConsultantInfoRepository : IBaseRepository<ConsultantInfo, ConsultantInfoFilter>
    {

    }

    internal class ConsultantInfoRepository : IConsultantInfoRepository
    {
        private readonly InvestmentServiceDbContext _dbContext;

        public ConsultantInfoRepository(InvestmentServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ConsultantInfo?> GetAsync(int id)
        {
            return await _dbContext.ConsultantInfo
                .Include(consultantInfo => consultantInfo.CustomerInfos)
                .ThenInclude(customerInfo => customerInfo.DiscretionaryRules)
                .SingleOrDefaultAsync(consultantInfo => consultantInfo.ConsultantInfoId == id);
        }

        public async Task<List<ConsultantInfo>> GetAsync(ConsultantInfoFilter? filter = null)
        {
            filter ??= new ConsultantInfoFilter();

            var consultantInfos = await _dbContext.ConsultantInfo
                .Include(consultantInfo => consultantInfo.CustomerInfos)
                .ThenInclude(customerInfo => customerInfo.DiscretionaryRules)
                .Where(consultantInfo =>
                    (!filter.ConsultantId.HasValue || consultantInfo.ConsultantInfoId == filter.ConsultantId)
                )
                .ToListAsync();

            return consultantInfos;
        }

        public async Task CreateAsync(ConsultantInfo model)
        {
            await _dbContext.ConsultantInfo.AddAsync(model);

        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }

    public class ConsultantInfoFilter : IBaseFilter
    {
        public int? ConsultantId { get; set; }
    }
}
