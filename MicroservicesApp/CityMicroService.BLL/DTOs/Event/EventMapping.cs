using AutoMapper;
using CityMicroService.DAL.Entities;

namespace CityMicroService.BLL.DTOs;

internal class EventMapping : Profile
{
    public EventMapping()
    {
        CreateMap<Event, EventDTO>().ReverseMap();
    }
}