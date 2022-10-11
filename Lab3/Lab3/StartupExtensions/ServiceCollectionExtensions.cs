using BLL.Services;
using DAL.RepositoryWrapper;

namespace Lab3.StartupExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServicesList(this IServiceCollection services)
    {
        services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
        services.AddTransient<ICategoryService, CategoryService>();

        return services;
    }
}
