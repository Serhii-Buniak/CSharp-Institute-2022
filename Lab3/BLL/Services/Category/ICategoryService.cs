using BLL.DTOs;

namespace BLL.Services;

public interface ICategoryService
{
    Task<CategoryDTO> GetByIdAsync(long id);
    Task<CategoryDTO> CreateAsync(CategoryDTO categoryDTO);
}