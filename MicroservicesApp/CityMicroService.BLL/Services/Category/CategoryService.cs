using AutoMapper;
using CityMicroService.BLL.DTOs;
using CityMicroService.DAL.Entities;
using CityMicroService.DAL.Repositories;
using CityMicroService.DAL.RepositoryWrapper;
using Microsoft.Extensions.Caching.Memory;

namespace CityMicroService.BLL.Services;

public class CategoryService : ICategoryService
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _memoryCache;

    public CategoryService(IRepositoryWrapper repositoryWrapper, IMapper mapper, IMemoryCache memoryCache)
    {
        _repositoryWrapper = repositoryWrapper;
        _categoryRepository = repositoryWrapper.CategoryRepository;
        _mapper = mapper;
        _memoryCache = memoryCache;
    }

    public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
    {
        IEnumerable<Category>? categories = _memoryCache.GetCategories();

        if (categories is null)
        {
            categories = await _categoryRepository.GetAllAsync();
            await Task.Delay(2500);
            _memoryCache.SetCategories(categories, 60);
        }

        return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
    }

    public async Task<CategoryDTO> GetByIdAsync(long id)
    {
        Category? category = await _categoryRepository.SingleOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            throw new ArgumentException(nameof(category), $"{nameof(Category)} with id {id} not exist");
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

    public async Task<CategoryDTO> DeleteAsync(long id)
    {
        Category? category = await _categoryRepository.SingleOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            throw new ArgumentException(nameof(category), $"{nameof(Category)} with id {id} not exist");
        }

        _categoryRepository.Delete(category);
        await _repositoryWrapper.SaveAsync();

        return _mapper.Map<CategoryDTO>(category);
    }

    public async Task<CategoryDTO> UpdateAsync(long id, CategoryDTO categoryDTO)
    {
        Category? category = await _categoryRepository.SingleOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            throw new ArgumentException(nameof(category), $"{nameof(Category)} with id {id} not exist");
        }

        category = _mapper.Map(categoryDTO, category);

        _categoryRepository.Update(category);
        await _repositoryWrapper.SaveAsync();

        return _mapper.Map<CategoryDTO>(category);
    }
}