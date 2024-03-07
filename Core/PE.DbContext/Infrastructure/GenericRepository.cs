using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PersionalExpenditureManagement.PE.DbContext.Infrastructure
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public readonly DbSet<TEntity> Repository;

        public GenericRepository(PEDbContext pEDbContext)
        {
            Repository = pEDbContext.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await Repository.ToListAsync();
        }

        // Expression<Func<TEntity, bool>> filter: cho phép bạn truyền vào một filter expression dạng LINQ
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = Repository;

            // Query là 1 dạng IQueryable, chỉ được thực thi khi cần giá trị list
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Tiếp theo, nó sẽ kèm theo các property cần thiết khi người dùng chỉ định
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            // Sau cùng, nó thực thi bằng cách translate thành câu lệnh SQL và gọi xuống database
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        // trong asp.net, Id cho 1 object có thể là GUID hoặc int
        public virtual TEntity GetByID(object id)
        {
            return Repository.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            Repository.Add(entity);
        }

        // trong asp.net, Id cho 1 object có thể là GUID hoặc int
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = Repository.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            Repository.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            Repository.Attach(entityToUpdate);
        }
    }
}
