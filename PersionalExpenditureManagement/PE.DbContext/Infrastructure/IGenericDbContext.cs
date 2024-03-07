namespace PersionalExpenditureManagement.PE.DbContext.Infrastructure
{
    public interface IGenericDbContext<T> where T : Microsoft.EntityFrameworkCore.DbContext, IPEDbContext, IDisposable
    {
    }
}
