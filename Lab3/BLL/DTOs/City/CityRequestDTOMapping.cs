using AutoMapper;
using DAL.Entities;

namespace BLL.DTOs;

internal class CityRequestDTOMapping : Profile
{
    public CityRequestDTOMapping()
    {
        CreateMap<City, CityRequestDTO>().ReverseMap();
    }
}