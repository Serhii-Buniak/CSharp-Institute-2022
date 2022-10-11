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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetApartment(long id)
    {
        CategoryDTO category = await _categoryService.GetByIdAsync(id);
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateApartment(CategoryDTO model)
    {
        CategoryDTO category = await _categoryService.CreateAsync(model);
        return CreatedAtAction(nameof(GetApartment), new { id = category.Id }, category);
    }
}