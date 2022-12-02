using AutoMapper;
using IdentityMicroService.DAL.Data;
using IdentityMicroService.Data;
using IdentityMicroService.Dtos;

namespace IdentityMicroService.Profiles;

public class ApplicationUserProfile : Profile
{
	public ApplicationUserProfile()
	{
        CreateMap<ApplicationUser, UserDto>();
        CreateMap<RegisterDto, ApplicationUser>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
    }
}