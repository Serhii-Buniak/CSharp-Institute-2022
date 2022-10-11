using AutoMapper;
using DAL.Entities;

namespace BLL.DTOs;

internal class GalleryMapping : Profile
{
    public GalleryMapping()
    {
        CreateMap<Gallery, GalleryDTO>().ReverseMap();
    }
}