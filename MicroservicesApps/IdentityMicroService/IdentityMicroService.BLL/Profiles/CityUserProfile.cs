using AutoMapper;
using IdentityMicroService.BLL.DAL.Data;
using IdentityMicroService.BLL.Dtos;
using IdentityMicroService.BLL.Protos;

namespace IdentityMicroService.BLL.Profiles;

public class CityUserProfile : Profile
{
    public CityUserProfile()
    {
        CreateMap<GrpcCountryModel, Country>()
            .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0));
        CreateMap<GrpcCityModel, City>()
            .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0));
    }
}
