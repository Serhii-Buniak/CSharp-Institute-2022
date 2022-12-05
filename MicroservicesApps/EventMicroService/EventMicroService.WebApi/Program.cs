using EventMicroService.Application;
using EventMicroService.Infrastructure;
using EventMicroService.WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddControllers(options =>
    options.Filters.Add<ApiExceptionFilterAttribute>()
);

services.AddApplicationServices();
services.AddInfrastructureServices(configuration);

const string corsName = "event-micro-service";
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
