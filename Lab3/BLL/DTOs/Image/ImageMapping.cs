using AutoMapper;
using DAL.Entities;

namespace BLL.DTOs;

internal class ImageMapping : Profile
{
    public ImageMapping()
    {
        CreateMap<Image, ImageDTO>().ReverseMap();
    }
}