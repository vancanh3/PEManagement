using Microsoft.EntityFrameworkCore;

namespace PersionalExpenditureManagement.PE.DbContext.Infrastructure
{
    public interface IPEDbContext
    {
        DbSet<T> Repository<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void Dispose();
    }
}
