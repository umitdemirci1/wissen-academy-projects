using GenericRepositoryAndUnitOfWork.Core.IRepository;
using GenericRepositoryAndUnitOfWork.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GenericRepositoryAndUnitOfWork.Core.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public AppDbContext context;
        public DbSet<T> dbSet;
        public ILogger logger;

        public GenericRepository(AppDbContext _context, ILogger _logger)
        {
            this.context = _context;
            this.logger = _logger;

            this.dbSet = context.Set<T>();
        }

        public async Task<bool> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter)
        {
            return await dbSet.Where(filter).ToListAsync();
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIDAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async virtual Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
