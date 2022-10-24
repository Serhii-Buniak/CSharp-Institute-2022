using AutoMapper;
using CityMicroService.DAL.Entities;

namespace CityMicroService.BLL.DTOs;

internal class RoleMapping : Profile
{
    public RoleMapping()
    {
        CreateMap<Role, RoleDTO>().ReverseMap();
    }
}