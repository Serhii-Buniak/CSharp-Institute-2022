using AutoMapper;
using Grpc.Core;
using Grpc.Net.Client;
using ImageMicroService.Application.Common.Interfaces;
using ImageMicroService.Infrastructure.Protos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ImageMicroService.Infrastructure.SyncServices.Grpc;

public class CityClient : ICityClient
{
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public CityClient(IConfiguration configuration, IMapper mapper)
    {
        _configuration = configuration;
        _mapper = mapper;
    }

    public void GetAllCities()
    {
        Console.WriteLine($"--> Calling GRPC Service {_configuration["GrpcCity"]}: ReturnAllPlatforms");

        GrpcChannel channel = GrpcChannel.ForAddress(_configuration["GrpcCity"]);

        GrpcCity.GrpcCityClient client = new(channel);
        GetAllRequest request = new();

        client.GetAllCities(request).City.ToList().ForEach(c => Console.WriteLine(c.Id));
    }
}
