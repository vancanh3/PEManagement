using PersionalExpenditureManagement.PE.DbContext.Models;

namespace PersionalExpenditureManagement.PE.DbContext.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private PEDbContext context;
        private GenericRepository<User> userRepository;
        private GenericRepository<SpendingCategory> spendingCategoryRepository;

        public UnitOfWork(PEDbContext pEDbContext)
        {
            context = pEDbContext;
        }

        // Kiểm tra xem repository đã được khởi tạo chưa
        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }

        // Kiểm tra xem repository đã được khởi tạo chưa
        public GenericRepository<SpendingCategory> SpendingCategoryRepository
        {
            get
            {
                if (this.spendingCategoryRepository == null)
                {
                    this.spendingCategoryRepository = new GenericRepository<SpendingCategory>(context);
                }
                return spendingCategoryRepository;
            }
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
    }
}
