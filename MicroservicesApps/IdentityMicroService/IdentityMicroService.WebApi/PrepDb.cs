using IdentityMicroService.BLL.Clients.Grpc;
using IdentityMicroService.BLL.DAL.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static IdentityMicroService.BLL.Constants.AuthorizationConfigs;

namespace IdentityMicroService.BLL.WebApi;

public static class PrepDb
{
    public static void PrepPopulation(WebApplicationBuilder builder)
    {
        using ServiceProvider provider = builder.Services.BuildServiceProvider();
        var context = provider.GetRequiredService<ApplicationDbContext>();
        var roleManager = provider.GetRequiredService<RoleManager<ApplicationRole>>();
        var cityClient = provider.GetRequiredService<ICityClient>();

        SeedData(context, roleManager, cityClient);
    }

    private static void SeedData(ApplicationDbContext context, RoleManager<ApplicationRole> roleManager, ICityClient cityClient)
    {
        context.Database.Migrate();

        IEnumerable<City> cities = cityClient.GetAllCities();
        IEnumerable<Country> countries = cityClient.GetAllCountries();

        foreach (Country country in countries)
        {
            if (!context.Countries.Any(c => c.ExternalId == country.ExternalId))
            {
                context.Countries.Add(country);
                context.SaveChanges();
            }
        }

        foreach (City city in cities)
        {
            if (!context.Cities.Any(c => c.ExternalId == city.ExternalId))
            {
                context.Cities.Add(city);
                context.SaveChanges();
            }
        }

        foreach (Roles key in roleDict.Keys)
        {
            string role = roleDict[key];
            if (!roleManager.Roles.Any(r => r.NormalizedName == role.ToUpper()))
            {
                roleManager.CreateAsync(new ApplicationRole(role)).Wait();
            }
        }
    }
}
