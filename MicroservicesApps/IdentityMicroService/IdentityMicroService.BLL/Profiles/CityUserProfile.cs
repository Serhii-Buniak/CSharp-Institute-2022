using AutoMapper;
using IdentityMicroService.BLL.DAL.Data;
using IdentityMicroService.BLL.Dtos;
using IdentityMicroService.BLL.Protos;

namespace IdentityMicroService.BLL.Profiles;

public class CityUserProfile : Profile
{
    public CityUserProfile()
    {
        CreateMap<GrpcCountryModel, Country>();
        CreateMap<GrpcCityModel, City>();
    }
}
