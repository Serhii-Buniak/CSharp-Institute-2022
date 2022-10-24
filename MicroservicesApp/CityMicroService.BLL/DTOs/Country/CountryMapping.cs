using AutoMapper;
using CityMicroService.DAL.Entities;

namespace CityMicroService.BLL.DTOs;

internal class CountryMapping : Profile
{
    public CountryMapping()
    {
        CreateMap<Country, CountryDTO>().ReverseMap();
    }
}