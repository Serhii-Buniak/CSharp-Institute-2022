using CityMicroService.BLL.DTOs;

namespace CityMicroService.BLL.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAllAsync();
    Task<CategoryDTO> GetByIdAsync(long id);
    Task<CategoryDTO> CreateAsync(CategoryDTO categoryDTO);
    Task<CategoryDTO> DeleteAsync(long id);
    Task<CategoryDTO> UpdateAsync(long id, CategoryDTO categoryDTO);
}