using Azure.Storage.Blobs;
using ImageMicroService.Infrastructure.Persistence;
using ImageMicroService.Infrastructure.SyncServices.Grpc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ImageMicroService.Infrastructure;

public static class PrepDb
{
    public static void PrepPopulation(WebApplicationBuilder builder)
    {
        using ServiceProvider provider = builder.Services.BuildServiceProvider();
        var client = provider.GetRequiredService<ICityClient>();
        client.GetAllCities();
        SeedData(provider.GetRequiredService<ApplicationDbContext>(), provider.GetRequiredService<BlobServiceClient>(), builder.Environment);
    }

    private static void SeedData(ApplicationDbContext context, BlobServiceClient client, IWebHostEnvironment env)
    {
        context.Database.Migrate();
        BlobContainerClient container = client.GetBlobContainerClient("images");
        if (container == null)
        {
            client.CreateBlobContainer("images");
        }
    }
}
