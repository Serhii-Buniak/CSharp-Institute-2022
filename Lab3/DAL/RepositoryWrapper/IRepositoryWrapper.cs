using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryWrapper;

public interface IRepositoryWrapper
{
    int Save();
    Task<int> SaveAsync();
}
