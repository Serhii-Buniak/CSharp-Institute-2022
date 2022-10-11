using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryWrapper;

public interface IRepositoryWrapper
{
    ICategoryRepository CategoryRepository { get; }
    int Save();
    Task<int> SaveAsync();
}
