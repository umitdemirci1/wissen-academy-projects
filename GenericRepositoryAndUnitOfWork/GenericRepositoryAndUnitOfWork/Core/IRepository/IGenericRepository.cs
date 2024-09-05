using System.Linq.Expressions;

namespace GenericRepositoryAndUnitOfWork.Core.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIDAsync(Guid id);

        Task<bool> AddAsync(T entity);
        //Task<Guid> AddAsync(T entity);
        //Task<T> AddAsync(T entity);

        Task<bool> UpdateAsync(T entity);
        //Task<bool> UpdateAsync(Guid id,T entity);
        Task<bool> DeleteAsync(Guid id);
        //Task<T> DeleteAsync(Guid id);
        //Task<T> DeleteAsync(T entity);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter);
    }
}
