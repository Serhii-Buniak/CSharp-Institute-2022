using AutoMapper;
using DAL.Entities;

namespace BLL.DTOs;

internal class RoleMapping : Profile
{
    public RoleMapping()
    {
        CreateMap<Role, RoleDTO>().ReverseMap();
    }
}