using System;
using System.Threading.Tasks;

namespace EntityFrameworkMock
{
    public interface IRepositoryBase<T>
    {
        Task<T> FindAsync(Int64 id);
    }
}
