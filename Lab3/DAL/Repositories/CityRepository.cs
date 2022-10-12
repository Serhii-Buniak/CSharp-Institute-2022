using DAL.Entities;
using DAL.RepositoryBase;

namespace DAL.Repositories;

public class CityRepository : RepositoryBase<City>, ICityRepository
{
    public CityRepository(ApplicationDbContext appDbContext) : base(appDbContext)
    {

    }
}