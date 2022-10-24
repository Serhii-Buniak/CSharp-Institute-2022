using AutoMapper;
using CityMicroService.DAL.Entities;

namespace CityMicroService.BLL.DTOs;

internal class CityRequestDTOMapping : Profile
{
    public CityRequestDTOMapping()
    {
        CreateMap<City, CityRequestDTO>().ReverseMap();
    }
}