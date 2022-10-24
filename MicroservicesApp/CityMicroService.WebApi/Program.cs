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
