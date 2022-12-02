using IdentityMicroService.DAL.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static IdentityMicroService.Constants.AuthorizationConfigs;

namespace IdentityMicroService.Data;

public static class PrepDb
{
    public static void PrepPopulation(WebApplicationBuilder builder)
    {
        using ServiceProvider provider = builder.Services.BuildServiceProvider();
        var context = provider.GetRequiredService<ApplicationDbContext>();
        var roleManager = provider.GetRequiredService<RoleManager<ApplicationRole>>();

        SeedData(context, roleManager);
    }

    private static void SeedData(ApplicationDbContext context, RoleManager<ApplicationRole> roleManager)
    {
        context.Database.Migrate();

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
