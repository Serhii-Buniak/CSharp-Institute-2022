
using AutoMapper;
using CityMicroService.BLL.DTOs;
using CityMicroService.DAL.Entities;
using CityMicroService.DAL.Repositories;
using CityMicroService.DAL.RepositoryWrapper;
using Microsoft.Extensions.Caching.Memory;

namespace CityMicroService.BLL.Services;

public class CountryService : ICountryService
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _memoryCache;

    public CountryService(IRepositoryWrapper repositoryWrapper, IMapper mapper, IMemoryCache memoryCache)
    {
        _repositoryWrapper = repositoryWrapper;
        _countryRepository = repositoryWrapper.CountryRepository;
        _mapper = mapper;
        _memoryCache = memoryCache;
    }

    public async Task<CountryDTO> CreateAsync(CountryRequestDTO cityRequest)
    {
        var country = _mapper.Map<Country>(cityRequest);

        await _countryRepository.CreateAsync(country);
        await _repositoryWrapper.SaveAsync();

        return await GetByIdAsync(country.Id);
    }

    public async Task<CountryDTO> DeleteAsync(long id)
    {
        Country? country = await _countryRepository.SingleOrDefaultAsync(c => c.Id == id);

        if (country == null)
        {
            throw new ArgumentException(nameof(country), $"{nameof(Country)} with id {id} not exist");
        }

        _countryRepository.Delete(country);
        await _repositoryWrapper.SaveAsync();

        return _mapper.Map<CountryDTO>(country);
    }

    public async Task<IEnumerable<CountryDTO>> GetAllAsync()
    {
        IEnumerable<Country>? countries = _memoryCache.GetCountries();

        if (countries is null)
        {
            countries = await _countryRepository.GetAllAsync();
            await Task.Delay(2500);
            _memoryCache.SetCountries(countries, 60);
        }

        return _mapper.Map<IEnumerable<CountryDTO>>(countries);
    }

    public async Task<CountryDTO> GetByIdAsync(long id)
    {
        Country? country = await _countryRepository.SingleOrDefaultAsync(c => c.Id == id);

        if (country == null)
        {
            throw new ArgumentException(nameof(country), $"{nameof(Country)} with id {id} not exist");
        }

        return _mapper.Map<CountryDTO>(country);
    }

    public async Task<CountryDTO> UpdateAsync(long id, CountryRequestDTO countryRequest)
    {
        Country? country = await _countryRepository.SingleOrDefaultAsync(c => c.Id == id);
        if (country == null)
        {
            throw new ArgumentException(nameof(country), $"{nameof(Country)} with id {id} not exist");
        }

        country = _mapper.Map(countryRequest, country);

        _countryRepository.Update(country);
        await _repositoryWrapper.SaveAsync();

        return _mapper.Map<CountryDTO>(country);
    }
}
