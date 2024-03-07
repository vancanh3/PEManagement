using PersionalExpenditureManagement.PE.DbContext;
using PersionalExpenditureManagement.PE.DbContext.Infrastructure;
using PersionalExpenditureManagement.PE.DbContext.Models;

namespace Core.PE.DbContext.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(PEDbContext dbContext) : base(dbContext)
        {
        }
    }
}
