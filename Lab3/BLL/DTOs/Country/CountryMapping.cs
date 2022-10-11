using AutoMapper;
using DAL.Entities;

namespace BLL.DTOs;

internal class CountryMapping : Profile
{
    public CountryMapping()
    {
        CreateMap<Country, CountryDTO>().ReverseMap();
    }
}