using AutoMapper;
using CityMicroService.DAL.Entities;

namespace CityMicroService.BLL.DTOs;

internal class MessageMapping : Profile
{
    public MessageMapping()
    {
        CreateMap<Message, MessageDTO>().ReverseMap();
    }
}