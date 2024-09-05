using GenericRepositoryAndUnitOfWork.Model;
using System.Linq.Expressions;

namespace GenericRepositoryAndUnitOfWork.Core.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        //Task<IEnumerable<User>> GetUsers(Expression<Func<User, bool>> filter);
    }
}
