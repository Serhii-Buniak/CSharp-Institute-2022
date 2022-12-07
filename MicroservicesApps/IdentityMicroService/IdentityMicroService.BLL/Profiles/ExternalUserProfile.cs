using AutoMapper;
using IdentityMicroService.BLL.DAL.Data;
using IdentityMicroService.BLL.Dtos;
using IdentityMicroService.BLL.Protos;
using IdentityMicroService.BLL.Subscribers;

namespace IdentityMicroService.BLL.Profiles;

public class ExternalUserProfile : Profile
{
    public ExternalUserProfile()
    {
        CreateMap<GrpcCountryModel, Country>();
        CreateMap<CountrySubscribed, Country>();
        CreateMap<GrpcCityModel, City>();
        CreateMap<City, CityDto>();
        CreateMap<ImageDto, Image>().ReverseMap();
    }
}
