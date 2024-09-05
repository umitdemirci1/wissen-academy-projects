using GenericRepositoryAndUnitOfWork.Core.IConfiguratin;
using GenericRepositoryAndUnitOfWork.Core.IRepository;
using GenericRepositoryAndUnitOfWork.Core.Repository;

namespace GenericRepositoryAndUnitOfWork.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private AppDbContext context;
        private ILogger logger;
        public IUserRepository Users 
        { 
            get;
            private set; 
        }

        public UnitOfWork(AppDbContext _context,ILoggerFactory _logger) 
        {
            context = _context;
            logger = _logger.CreateLogger("ApplicationLogs");

            Users = new UserRepository(context, logger);
        }

        public async Task ComplateAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
