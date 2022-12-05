using AutoMapper;
using CityMicroService.BLL.DTOs;
using CityMicroService.BLL.Protos;
using CityMicroService.BLL.Services;
using Grpc.Core;

namespace CityMicroService.WebApi.GrpcControllers;

public class CityGrpcController : GrpcCity.GrpcCityBase
{
    private readonly ICityService _cityService;
    private readonly IMapper _mapper;

    public CityGrpcController(ICityService cityService, IMapper mapper, ILogger<CityGrpcController> logger)
    {
        _cityService = cityService;
        _mapper = mapper;
    }

    public override async Task<CitiesResponse> GetAllCities(GetAllRequest request, ServerCallContext context)
    {
        CitiesResponse response = new();
       
        IEnumerable<CityDTO> cities = await _cityService.GetAllAsync();
        var models = _mapper.Map<IEnumerable<GrpcCityModel>>(cities);
        Console.WriteLine("CitiesResponse");
        response.City.AddRange(models);
        return response;
    }
}