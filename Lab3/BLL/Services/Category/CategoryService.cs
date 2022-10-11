using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using DAL.Repositories;
using DAL.RepositoryWrapper;

namespace BLL.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _categoryRepository = repositoryWrapper.CategoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDTO> GetByIdAsync(long id)
    {
        Category? category = await _categoryRepository.FindAsync(id);

        if (category == null)
        {
            throw new Exception();
        }

        return _mapper.Map<CategoryDTO>(category);
    }
}