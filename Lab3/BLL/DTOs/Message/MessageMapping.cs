using AutoMapper;
using DAL.Entities;

namespace BLL.DTOs;

internal class MessageMapping : Profile
{
    public MessageMapping()
    {
        CreateMap<Message, MessageDTO>().ReverseMap();
    }
}