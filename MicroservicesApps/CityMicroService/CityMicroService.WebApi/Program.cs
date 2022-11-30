using CityMicroService.BLL;
using CityMicroService.DAL;
using CityMicroService.WebApi.StartupExtensions;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddFluentValidationAutoValidation();
services.AddValidatorsFromAssembly(typeof(AssemblyEntryPoint).Assembly);

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddAutoMapper(typeof(AssemblyEntryPoint).Assembly);
services.AddMemoryCache();

services.AddServicesList();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

const string corsName = "city-micro-service";
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
