using AutoMapper;
using IdentityMicroService.BLL.DAL.Data;
using IdentityMicroService.BLL.Dtos;

namespace IdentityMicroService.BLL.Profiles;

public class ApplicationUserProfile : Profile
{
	public ApplicationUserProfile()
	{
        CreateMap<ApplicationUser, UserDto>()
             .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name));
        CreateMap<RegisterDto, ApplicationUser>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
    }
}