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

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(builder);

app.Run();
