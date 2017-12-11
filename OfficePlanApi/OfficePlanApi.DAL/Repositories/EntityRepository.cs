using OfficePlanApi.DAL.DbContexts;
using OfficePlanApi.Domain.Entities;
using OfficePlanApi.Domain.Helpers;
using OfficePlanApi.Domain.Interfaces.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace OfficePlanApi.DAL.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T>
        where T : BaseEntity
    {
        private readonly OfficePlanDbContext _dbContext;

        public EntityRepository(OfficePlanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public async Task Create(T entity)
        {
            LogicalGuard.ExpectArgumentIsNotNull(() => entity);

            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            LogicalGuard.ExpectArgumentIsNotNull(() => entity);

            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            LogicalGuard.ExpectArgumentIsNotNull(() => entity);

            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
