using AutoMapper;
using IdentityMicroService.BLL.DAL.Data;
using IdentityMicroService.BLL.Dtos;
using IdentityMicroService.BLL.Protos;

namespace IdentityMicroService.BLL.Profiles;

public class ExternalUserProfile : Profile
{
    public ExternalUserProfile()
    {
        CreateMap<GrpcCountryModel, Country>();
        CreateMap<GrpcCityModel, City>();
        CreateMap<City, CityDto>();
        CreateMap<ImageDto, Image>().ReverseMap();
    }
}
