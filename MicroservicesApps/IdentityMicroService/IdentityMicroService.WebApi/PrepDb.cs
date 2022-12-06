using IdentityMicroService.BLL.Clients.Grpc;
using IdentityMicroService.BLL.DAL.Data;
using IdentityMicroService.BLL.Protos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Linq;
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


        IEnumerable<Country> countries = cityClient.GetAllCountries().Select(c => new Country
        {
            Id = c.Id,
            Name = c.Name,
        });

        foreach (Country country in countries)
        {
            if (!context.Countries.Any(c => c.Id == country.Id))
            {
                context.Countries.Add(country);
            }
            else
            {
                context.Countries.Update(country);
            }
        }

        IEnumerable<Country> deletedCountries = context.Countries.ToList().Except(countries);

        context.Countries.RemoveRange(deletedCountries);

        context.SaveChanges();


        IEnumerable<City> cities = cityClient.GetAllCities().Select(c => new City
        {
            Id = c.Id,
            Name = c.Name,
            CountryId = c.CountryId
        });

        foreach (City city in cities)
        {
            if (!context.Cities.Any(c => c.Id == city.Id))
            {

                context.Cities.Add(city);
            }
            else
            {
                context.Cities.Update(city);
            }
        }

        IEnumerable<City> deletedCities = context.Cities.ToList().Except(cities);

        context.Cities.RemoveRange(deletedCities);

        context.SaveChanges();


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
