namespace PersionalExpenditureManagement.PE.DbContext.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
