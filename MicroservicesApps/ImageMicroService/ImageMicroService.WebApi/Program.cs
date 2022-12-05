using ImageMicroService.Infrastructure;
using ImageMicroService.WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers(options =>
    options.Filters.Add<ApiExceptionFilterAttribute>()
);

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddApplicationServices();
services.AddInfrastructureServices(configuration);

const string corsName = "image-micro-service";
services.AddCors(options =>
{
    options.AddPolicy(corsName,
    corsbuilder =>
    {
        corsbuilder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin();
    });
});

var app = builder.Build();

app.UseCors(corsName);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(builder);

app.Run();
