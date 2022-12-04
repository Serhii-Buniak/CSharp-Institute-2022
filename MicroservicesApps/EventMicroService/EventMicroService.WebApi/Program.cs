using EventMicroService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

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
