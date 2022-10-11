using AutoMapper;
using DAL.Entities;

namespace BLL.DTOs;

internal class EventMapping : Profile
{
    public EventMapping()
    {
        CreateMap<Event, EventDTO>().ReverseMap();
    }
}