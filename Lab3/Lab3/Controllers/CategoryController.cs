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
    public async Task<IActionResult> GetApartments()
    {
        IEnumerable<CategoryDTO> categories = await _categoryService.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetApartment(long id)
    {
        try
        {
            CategoryDTO category = await _categoryService.GetByIdAsync(id);
            return Ok(category);
        }
        catch (ArgumentNullException e)
        {
            return NotFound(new { error = e.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateApartment(CategoryDTO categoryDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        categoryDTO = await _categoryService.CreateAsync(categoryDTO);
        return CreatedAtAction(nameof(GetApartment), new { Id = categoryDTO.Id }, categoryDTO);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateApartment(long id, CategoryDTO categoryDTO)
    {
        if (id != categoryDTO.Id)
        {
            return BadRequest(new { error = $"Id {nameof(categoryDTO)} not equal {id}" });
        }

        categoryDTO = await _categoryService.UpdateAsync(id, categoryDTO);
        return CreatedAtAction(nameof(GetApartment), new { Id = id }, categoryDTO);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteApartment(long id)
    {
        await _categoryService.DeleteAsync(id);
        return NoContent();
    }
}