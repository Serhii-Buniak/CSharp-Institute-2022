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

    public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
    {
        IEnumerable<Category> categories = await _categoryRepository.GetAllAsync();
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