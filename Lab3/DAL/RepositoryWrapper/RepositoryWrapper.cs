using DAL.Repositories;

namespace DAL.RepositoryWrapper;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly ApplicationDbContext _appDbContext;

    private CategoryRepository? _categoryRepository;  
    private CityRepository? _cityRepository;

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

    public int Save()
    {
        return _appDbContext.SaveChanges();
    }

    public async Task<int> SaveAsync()
    {
        return await _appDbContext.SaveChangesAsync();
    }
}
