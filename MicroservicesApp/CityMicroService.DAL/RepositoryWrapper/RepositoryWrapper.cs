using CityMicroService.DAL.Repositories;

namespace CityMicroService.DAL.RepositoryWrapper;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly ApplicationDbContext _appDbContext;

    private CategoryRepository? _categoryRepository;  
    private CityRepository? _cityRepository;
    private CountryRepository? _countryRepository;

    public RepositoryWrapper(ApplicationDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public ICategoryRepository CategoryRepository {
        get
        {
            if (_categoryRepository == null)
                _categoryRepository = new CategoryRepository(_appDbContext);
            return _categoryRepository;
        }
    }

    public ICityRepository CityRepository
    {
        get
        {
            if (_cityRepository == null)
                _cityRepository = new CityRepository(_appDbContext);
            return _cityRepository;
        }
    }

    public ICountryRepository CountryRepository
    {
        get
        {
            if (_countryRepository == null)
                _countryRepository = new CountryRepository(_appDbContext);
            return _countryRepository;
        }
    }

    public int Save()
    {
        return _appDbContext.SaveChanges();
    }

    public async Task<int> SaveAsync()
    {
        return await _appDbContext.SaveChangesAsync();
    }
}
