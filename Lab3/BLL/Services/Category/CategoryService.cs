using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using DAL.Repositories;
using DAL.RepositoryWrapper;

namespace BLL.Services;

public class CategoryService : ICategoryService
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _categoryRepository = repositoryWrapper.CategoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDTO> GetByIdAsync(long id)
    {
        Category? category = await _categoryRepository.FindAsync(id);

        if (category == null)
        {
            throw new ArgumentException($"{nameof(Category)} with {nameof(id)} id not exist", nameof(id));
        }

        return _mapper.Map<CategoryDTO>(category);
    }

    public async Task<CategoryDTO> CreateAsync(CategoryDTO categoryDTO)
    {
        Category category = _mapper.Map<Category>(categoryDTO);

        await _categoryRepository.CreateAsync(category);
        await _repositoryWrapper.SaveAsync();

        return _mapper.Map<CategoryDTO>(category);
    }
}