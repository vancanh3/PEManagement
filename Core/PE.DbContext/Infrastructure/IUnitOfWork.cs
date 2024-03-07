using Microsoft.EntityFrameworkCore;

namespace PersionalExpenditureManagement.PE.DbContext.Infrastructure
{
    public interface IUnitOfWork
    {
        GenericRepository<T> GenericDB<T>() where T : class;
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
