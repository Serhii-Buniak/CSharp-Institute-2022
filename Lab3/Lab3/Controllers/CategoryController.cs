using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        IEnumerable<CategoryDTO> categories = await _categoryService.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(long id)
    {
        try
        {
            CategoryDTO category = await _categoryService.GetByIdAsync(id);
            return Ok(category);
        }
        catch (ArgumentException e)
        {
            return NotFound(new { error = e.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CategoryDTO categoryDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        categoryDTO = await _categoryService.CreateAsync(categoryDTO);
        return CreatedAtAction(nameof(GetCategory), new { Id = categoryDTO.Id }, categoryDTO);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(long id, CategoryDTO categoryDTO)
    {
        if (id != categoryDTO.Id)
        {
            return BadRequest(new { error = $"Id {nameof(categoryDTO)} not equal {id}" });
        }
        try
        {
            categoryDTO = await _categoryService.UpdateAsync(id, categoryDTO);
            return CreatedAtAction(nameof(GetCategory), new { Id = id }, categoryDTO);
        }
        catch (ArgumentException e)
        {
            return NotFound(new { error = e.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(long id)
    {
        try
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
        catch (ArgumentException e)
        {
            return NotFound(new { error = e.Message });
        }
    }
}