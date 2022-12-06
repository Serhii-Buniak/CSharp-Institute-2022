using AutoMapper;
using IdentityMicroService.BLL.Clients.Grpc;
using IdentityMicroService.BLL.DAL.Data;
using IdentityMicroService.BLL.Protos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        var mapper = provider.GetRequiredService<IMapper>();

        SeedData(context, roleManager, cityClient, mapper);
    }

    private static void SeedData(ApplicationDbContext context, RoleManager<ApplicationRole> roleManager, ICityClient cityClient, IMapper mapper)
    {
        context.Database.Migrate();


        var externalCountries = mapper.Map<IEnumerable<Country>>(cityClient.GetAllCountries());
        var existCountries = context.Countries.AsNoTracking().AsEnumerable();

        IEnumerable<Country> diffCountries = existCountries.Except(externalCountries);

        context.Countries.RemoveRange(diffCountries);
  
        foreach (Country country in externalCountries)
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
        context.SaveChanges();


        var externalCities = mapper.Map<IEnumerable<City>>(cityClient.GetAllCities());
        var existCities = context.Cities.AsNoTracking().AsEnumerable();

        IEnumerable<City> diffCities= existCities.Except(externalCities);

        context.Cities.RemoveRange(diffCities);

        foreach (City city in externalCities)
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
