using System.Data.Entity;
using System.Threading.Tasks;
using JustMockTest;
using TimeSketch.Core.Entity.Interface;

namespace EntityFrameworkMock
{

    public class BaseRepository<T> : IRepositoryBase<T> where T : class, IEntity, new()
    {
        protected readonly DbContext InnerDbContext;
        protected DbSet<T> InnerDbSet;

        public BaseRepository(IDbContext innerDbContext)
        {
            InnerDbContext = innerDbContext as DbContext;
            InnerDbSet = innerDbContext.Set<T>();
        }
       
        public virtual Task<T> FindAsync(long id)
        {
            return InnerDbSet.FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}