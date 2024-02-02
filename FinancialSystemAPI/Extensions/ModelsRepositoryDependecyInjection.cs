using FinancialSystemAPI.Context.Repositories;
using FinancialSystemAPI.Models.Interfaces;

namespace FinancialSystemAPI.Extensions;

public static class ModelsRepositoryDependecyInjection
{
    public static IServiceCollection AddModelsRepositoryDependecyInjection(this IServiceCollection services)
    {
        return services.AddScoped<IAccountRepository, AccountRepository>();
    }
}