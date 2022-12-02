using AutoMapper;
using IdentityMicroService.DAL.Data;
using IdentityMicroService.Data;
using IdentityMicroService.Dtos;
using Microsoft.AspNetCore.Identity;

namespace IdentityMicroService.Profiles;

public class ApplicationRoleProfile : Profile
{
	public ApplicationRoleProfile()
	{
        CreateMap<ApplicationRole, RoleDto>();
    }
}
