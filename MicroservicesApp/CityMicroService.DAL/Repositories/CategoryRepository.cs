using CityMicroService.DAL.Entities;
using CityMicroService.DAL.RepositoryBase;

namespace CityMicroService.DAL.Repositories;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext appDbContext) : base(appDbContext)
    {

    }
}
