using AutoMapper;
using DAL.Entities;

namespace BLL.DTOs;

internal class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User, UserDTO>().ReverseMap();
    }
}