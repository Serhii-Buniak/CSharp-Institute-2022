namespace DAL.RepositoryWrapper;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly ApplicationDbContext _appDbContext;

    public RepositoryWrapper(ApplicationDbContext appDbContext)
    {
        _appDbContext = appDbContext;
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
