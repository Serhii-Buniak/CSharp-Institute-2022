using AutoMapper;
using DAL.Entities;

namespace BLL.DTOs;

internal class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
    }
}