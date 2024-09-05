using GenericRepositoryAndUnitOfWork.Core.IRepository;
using GenericRepositoryAndUnitOfWork.Data;
using GenericRepositoryAndUnitOfWork.Model;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryAndUnitOfWork.Core.Repository
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public UserRepository(AppDbContext _context,ILogger _logger):base(_context,_logger)
        {

        }

        public async override  Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                User user = await dbSet.Where(x => x.UserId == id).FirstOrDefaultAsync();

                if (user == null)
                    return false;

                dbSet.Remove(user);
                return true;
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "User Repository Delete Method Error", typeof(UserRepository));
                return false;
            }
        }

        public async override Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                return dbSet.ToList();
            }
            catch (Exception ex) 
            {
                logger.LogError("User Repository GetAll Method error",typeof(UserRepository), ex);
                return Enumerable.Empty<User>();
            }
        }

        public async override Task<bool> UpdateAsync(User entity)
        {
            try
            {
                User existingUser = dbSet.Where(x => x.UserId == entity.UserId).FirstOrDefault();

                if (existingUser == null)
                    return await AddAsync(entity);

                existingUser.FirstName = entity.FirstName;
                existingUser.LastName = entity.LastName;
                existingUser.Email = entity.Email;
                existingUser.Phone = entity.Phone;
                existingUser.Address = entity.Address;
                return true;
            }
            catch(Exception ex)
            {
                logger.LogError("User Repository Update Method Error", typeof(UserRepository), ex);
                return false;
            }
        }
    }
}
