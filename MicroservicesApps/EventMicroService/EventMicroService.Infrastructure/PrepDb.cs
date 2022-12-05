using EventMicroService.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventMicroService.Infrastructure;

public static class PrepDb
{
    public static void PrepPopulation(WebApplicationBuilder builder)
    {
        using ServiceProvider provider = builder.Services.BuildServiceProvider();
        var context = provider.GetRequiredService<ApplicationDbContext>();

        SeedData(context);
    }

    private static void SeedData(ApplicationDbContext context)
    {
        context.Database.Migrate();
    }
}