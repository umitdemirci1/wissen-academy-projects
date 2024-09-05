using GenericRepositoryAndUnitOfWork.Core.IRepository;

namespace GenericRepositoryAndUnitOfWork.Core.IConfiguratin
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        Task ComplateAsync();
    }
}
