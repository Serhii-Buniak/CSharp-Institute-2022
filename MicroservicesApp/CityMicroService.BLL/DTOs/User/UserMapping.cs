using AutoMapper;
using CityMicroService.DAL.Entities;

namespace CityMicroService.BLL.DTOs;

internal class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User, UserDTO>().ReverseMap();
    }
}