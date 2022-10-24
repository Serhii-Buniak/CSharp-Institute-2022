using AutoMapper;
using CityMicroService.DAL.Entities;

namespace CityMicroService.BLL.DTOs;

internal class CityDTOMapping : Profile
{
    public CityDTOMapping()
    {
        CreateMap<City, CityDTO>().ReverseMap();
    }
}