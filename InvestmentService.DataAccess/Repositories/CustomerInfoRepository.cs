using InvestmentService.DataAccess.Models;
using InvestmentService.DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace InvestmentService.DataAccess.Repositories
{
    public interface ICustomerInfoRepository : IBaseRepository<CustomerInfo, CustomerInfoFilter>
    {

    }

    internal class CustomerInfoRepository : ICustomerInfoRepository
    {
        private readonly InvestmentServiceDbContext _dbContext;

        public CustomerInfoRepository(InvestmentServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerInfo?> GetAsync(int id)
        {
            return await _dbContext.CustomerInfo.SingleOrDefaultAsync(customerInfo => customerInfo.CustomerId == id);
        }

        public async Task<List<CustomerInfo>> GetAsync(CustomerInfoFilter? filter = null)
        {
            filter ??= new CustomerInfoFilter();

            var customerInfos = await _dbContext.CustomerInfo
                .Where(customerInfo =>
                    (!filter.CustomerId.HasValue || customerInfo.CustomerId == filter.CustomerId)
                    && (!filter.ConsultantId.HasValue || customerInfo.ConsultantId == filter.ConsultantId)
                )
                .ToListAsync();

            return customerInfos;
        }

        public async Task CreateAsync(CustomerInfo model)
        {
            await _dbContext.CustomerInfo.AddAsync(model);

        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }

    public class CustomerInfoFilter : IBaseFilter
    {
        public int? CustomerId { get; set; }
        public int? ConsultantId { get; set; }
    }
}
