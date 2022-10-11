using AutoMapper;
using DAL.Entities;

namespace BLL.DTOs;

internal class CityMapping : Profile
{
    public CityMapping()
    {
        CreateMap<City, CityDTO>().ReverseMap();
    }
}