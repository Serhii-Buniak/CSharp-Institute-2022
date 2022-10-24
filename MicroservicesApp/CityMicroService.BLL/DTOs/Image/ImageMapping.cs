using AutoMapper;
using CityMicroService.DAL.Entities;

namespace CityMicroService.BLL.DTOs;

internal class ImageMapping : Profile
{
    public ImageMapping()
    {
        CreateMap<Image, ImageDTO>().ReverseMap();
    }
}