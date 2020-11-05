using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Contracts
{
    public interface IGenericRepositoryFactory
    {
        T GetGenericRepository<T>() where T : IGenericRepository;
    }
}
