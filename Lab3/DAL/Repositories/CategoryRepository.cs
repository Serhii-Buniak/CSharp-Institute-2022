using DAL.Entities;
using DAL.RepositoryBase;

namespace DAL.Repositories;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext appDbContext) : base(appDbContext)
    {

    }
}