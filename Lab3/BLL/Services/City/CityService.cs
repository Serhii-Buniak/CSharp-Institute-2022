using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using DAL.Repositories;
using DAL.RepositoryWrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BLL.Services;

public class CityService : ICityService
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public static Func<IQueryable<City>, IIncludableQueryable<City, object>> Include => city => city.Include(c => c.Country);

    public CityService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _cityRepository = repositoryWrapper.CityRepository;
        _cityRepository.Include = Include;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CityDTO>> GetAllAsync()
    {
        IEnumerable<City> cities = await _cityRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CityDTO>>(cities);
    }

    public async Task<CityDTO> GetByIdAsync(long id)
    {
        City? city = await _cityRepository.SingleOrDefaultAsync(c => c.Id == id);

        if (city == null)
        {
            throw new ArgumentNullException(nameof(city), $"{nameof(City)} with id {id} not exist");
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
            throw new ArgumentNullException(nameof(city), $"{nameof(City)} with id {id} not exist");
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
            throw new ArgumentNullException(nameof(city), $"{nameof(City)} with id {id} not exist");
        }

        city = _mapper.Map(cityRequest, city);

        _cityRepository.Update(city);
        await _repositoryWrapper.SaveAsync();

        return _mapper.Map<CityDTO>(city);
    }
}