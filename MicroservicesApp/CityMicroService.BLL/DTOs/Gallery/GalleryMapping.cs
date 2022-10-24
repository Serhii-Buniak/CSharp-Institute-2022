using AutoMapper;
using CityMicroService.DAL.Entities;

namespace CityMicroService.BLL.DTOs;

internal class GalleryMapping : Profile
{
    public GalleryMapping()
    {
        CreateMap<Gallery, GalleryDTO>().ReverseMap();
    }
}