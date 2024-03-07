using Microsoft.EntityFrameworkCore;
using PersionalExpenditureManagement.PE.DbContext.Models;

namespace PersionalExpenditureManagement.PE.DbContext.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private PEDbContext context;

        public UnitOfWork(PEDbContext pEDbContext)
        {
            context = pEDbContext;
        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Rollback()
        {
            context.Dispose();
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task RollbackAsync()
        {
            await context.DisposeAsync();
        }

        public GenericRepository<T> GenericDB<T>() where T : class
        {
            return new GenericRepository<T>(context);
        }
    }
}
