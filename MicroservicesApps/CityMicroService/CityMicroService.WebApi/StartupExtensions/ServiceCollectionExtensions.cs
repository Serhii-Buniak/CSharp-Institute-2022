using CityMicroService.BLL.Services;
using CityMicroService.DAL.RepositoryWrapper;

namespace CityMicroService.WebApi.StartupExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServicesList(this IServiceCollection services)
    {
        services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
        services.AddTransient<ICountryService, CountryService>();
        services.AddTransient<ICityService, CityService>();

        return services;
    }
}
