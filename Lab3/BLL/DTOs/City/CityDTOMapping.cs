using AutoMapper;
using DAL.Entities;

namespace BLL.DTOs;

internal class CityDTOMapping : Profile
{
    public CityDTOMapping()
    {
        CreateMap<City, CityDTO>().ReverseMap();
    }
}