using WebApi.Filters;

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
