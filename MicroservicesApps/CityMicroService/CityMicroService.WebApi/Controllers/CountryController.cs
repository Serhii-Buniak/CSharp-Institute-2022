using CityMicroService.BLL.DTOs;
using CityMicroService.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityMicroService.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCities()
    {
        IEnumerable<CountryDTO> countryDTOs = await _countryService.GetAllAsync();
        return Ok(countryDTOs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCity(long id)
    {
        try
        {
            CountryDTO countryDTO = await _countryService.GetByIdAsync(id);
            return Ok(countryDTO);
        }
        catch (ArgumentException e)
        {
            return NotFound(new { error = e.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateCity(CountryRequestDTO countryRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        CountryDTO country = await _countryService.CreateAsync(countryRequest);
        return CreatedAtAction(nameof(GetCity), new { Id = country.Id }, country);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCity(long id, CountryRequestDTO cityRequest)
    {
        try
        {
            CountryDTO country = await _countryService.UpdateAsync(id, cityRequest);
            return CreatedAtAction(nameof(GetCity), new { Id = id }, country);
        }
        catch (ArgumentException e)
        {
            return NotFound(new { error = e.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCity(long id)
    {
        try
        {
            await _countryService.DeleteAsync(id);
            return NoContent();
        }
        catch (ArgumentException e)
        {
            return NotFound(new { error = e.Message });
        }
    }
}
