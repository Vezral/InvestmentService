using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InvestmentService.DataAccess
{
    public static class StartupExtension
    {
        public static IServiceCollection AddInvestmentServiceDatabase(this IServiceCollection serviceCollection, DatabaseOption databaseOption)
        {
            serviceCollection.Scan(scan =>
                scan.FromAssemblyOf<InvestmentServiceDbContext>()
                        .AddClasses(publicOnly: false)
                            .AsMatchingInterface()
                            .WithScopedLifetime()
            );
            serviceCollection.AddDbContext<InvestmentServiceDbContext>(option =>
                option.UseSqlServer(databaseOption.ConnectionString)
            );
            return serviceCollection;
        }
    }
}