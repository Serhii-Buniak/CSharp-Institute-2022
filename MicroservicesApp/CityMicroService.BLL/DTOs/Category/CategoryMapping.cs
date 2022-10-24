using AutoMapper;
using CityMicroService.DAL.Entities;

namespace CityMicroService.BLL.DTOs;

internal class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
    }
}