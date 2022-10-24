using AutoMapper;
using CityMicroService.BLL.DTOs;
using CityMicroService.DAL.Entities;
using CityMicroService.DAL.Repositories;
using CityMicroService.DAL.RepositoryWrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Caching.Memory;

namespace CityMicroService.BLL.Services;

public class CityService : ICityService
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly ICityRepository _cityRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _memoryCache;

    public static Func<IQueryable<City>, IIncludableQueryable<City, object>> Include => city => city.Include(c => c.Country);

    public CityService(IRepositoryWrapper repositoryWrapper, IMapper mapper, IMemoryCache memoryCache)
    {
        _repositoryWrapper = repositoryWrapper;
        _cityRepository = repositoryWrapper.CityRepository;
        _countryRepository = repositoryWrapper.CountryRepository;
        _cityRepository.Include = Include;
        _mapper = mapper;
        _memoryCache = memoryCache;
    }

    public async Task<IEnumerable<CityDTO>> GetAllAsync()
    {
        IEnumerable<City>? cities = _memoryCache.GetCities();

        if (cities is null)
        {
            cities = await _cityRepository.GetAllAsync();
            await Task.Delay(2500);
            _memoryCache.SetCities(cities, 60);
        }

        cities = await _cityRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CityDTO>>(cities);
    }

    public async Task<CityDTO> GetByIdAsync(long id)
    {
        City? city = await _cityRepository.SingleOrDefaultAsync(c => c.Id == id);

        if (city == null)
        {
            throw new ArgumentException(nameof(city), $"{nameof(City)} with id {id} not exist");
        }

        return _mapper.Map<CityDTO>(city);
    }

    public async Task<CityDTO> CreateAsync(CityRequestDTO cityRequest)
    {
        City city = _mapper.Map<City>(cityRequest);

        await _cityRepository.CreateAsync(city);
        await _repositoryWrapper.SaveAsync();

        return await GetByIdAsync(city.Id);
    }

    public async Task<CityDTO> DeleteAsync(long id)
    {
        City? city = await _cityRepository.SingleOrDefaultAsync(c => c.Id == id);

        if (city == null)
        {
            throw new ArgumentException(nameof(city), $"{nameof(City)} with id {id} not exist");
        }

        _cityRepository.Delete(city);
        await _repositoryWrapper.SaveAsync();

        return _mapper.Map<CityDTO>(city);
    }

    public async Task<CityDTO> UpdateAsync(long id, CityRequestDTO cityRequest)
    {
        City? city = await _cityRepository.SingleOrDefaultAsync(c => c.Id == id);
        if (city == null)
        {
            throw new ArgumentException(nameof(city), $"{nameof(City)} with id {id} not exist");
        }

        city = _mapper.Map(cityRequest, city);

        Country? country = await _countryRepository.SingleOrDefaultAsync(c => c.Id == city.CountryId);
        if (country == null)
        {
            throw new ArgumentException(nameof(country), $"{nameof(Country)} with id {id} not exist");
        }

        city.Country = country;
        _cityRepository.Update(city);
        await _repositoryWrapper.SaveAsync();

        return _mapper.Map<CityDTO>(city);
    }
}