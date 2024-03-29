﻿namespace FinancialSystemAPI.Extensions;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDataBaseDependecyInjection(configuration)
            .AddModelsRepositoryDependecyInjection();
    }
}
