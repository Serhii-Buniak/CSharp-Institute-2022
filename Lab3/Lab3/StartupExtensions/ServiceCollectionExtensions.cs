using DAL.RepositoryWrapper;

namespace Lab3.StartupExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServicesList(this IServiceCollection services)
    {
        services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();

        return services;
    }
}
