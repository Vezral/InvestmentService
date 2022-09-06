namespace InvestmentService.DataAccess.Repositories.Base
{
    public interface IBaseRepository<TModel, TFilter>
        where TModel : class
        where TFilter : IBaseFilter
    {
        public Task<TModel?> GetAsync(int id);
        public Task<List<TModel>> GetAsync(TFilter? filter = default);
        public Task CreateAsync(TModel model);
        public Task SaveAsync();
    }
}
