using InvestmentService.DataAccess.Models;
using InvestmentService.DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace InvestmentService.DataAccess.Repositories
{
    public interface IDiscretionaryRuleRepository : IBaseRepository<DiscretionaryRule, DiscretionaryRuleFilter>
    {

    }

    internal class DiscretionaryRuleRepository : IDiscretionaryRuleRepository
    {
        private readonly InvestmentServiceDbContext _dbContext;

        public DiscretionaryRuleRepository(InvestmentServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DiscretionaryRule?> GetAsync(int id)
        {
            return await _dbContext.DiscretionaryRules
                .Include(discretionaryInfo => discretionaryInfo.ConsultantInfo)
                .Include(discretionaryInfo => discretionaryInfo.CustomerInfo)
                .SingleOrDefaultAsync(discretionaryRule => discretionaryRule.DiscretionaryRuleId == id);
        }

        public async Task<List<DiscretionaryRule>> GetAsync(DiscretionaryRuleFilter? filter = null)
        {
            filter ??= new DiscretionaryRuleFilter();

            var discretionaryRules = await _dbContext.DiscretionaryRules
                .Include(discretionaryInfo => discretionaryInfo.ConsultantInfo)
                .Include(discretionaryInfo => discretionaryInfo.CustomerInfo)
                .Where(discretionaryRule =>
                    (!filter.CustomerId.HasValue || discretionaryRule.CustomerId == filter.CustomerId)
                    && (!filter.ConsultantId.HasValue || discretionaryRule.ConsultantId == filter.ConsultantId)
                )
                .ToListAsync();

            return discretionaryRules;
        }

        public async Task CreateAsync(DiscretionaryRule model)
        {
            await _dbContext.DiscretionaryRules.AddAsync(model);

        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }

    public class DiscretionaryRuleFilter : IBaseFilter
    {
        public int? CustomerId { get; set; }
        public int? ConsultantId { get; set; }
    }
}
