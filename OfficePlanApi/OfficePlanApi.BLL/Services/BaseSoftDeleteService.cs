using OfficePlanApi.Domain.Entities;
using OfficePlanApi.Domain.Extensions;
using OfficePlanApi.Domain.Helpers;
using OfficePlanApi.Domain.Interfaces.Repositories;
using OfficePlanApi.Domain.Interfaces.Services;
using OfficePlanApi.Domain.Interfaces.WorkContexts;
using System.Linq;
using System.Threading.Tasks;

namespace OfficePlanApi.BLL.Services
{
    public class BaseSoftDeleteService<T> : BaseService<T>, IBaseSoftDeleteService<T>
        where T : BaseEntitySoftDelete
    {
        public BaseSoftDeleteService(
            IEntityRepository<T> entityRepository,
            IBaseWorkContext workContext,
            IDateTimeService dateTimeService)
            : base(entityRepository, workContext, dateTimeService)
        {
        }

        public Task<T> GetByIdAsync(int entityId, bool allowDeleted)
        {
            if (entityId == 0)
            {
                return null;
            }

            if (!allowDeleted)
            {
                return GetByIdAsync(entityId);
            }

            var result = base.GetQueryableAll().SingleOrDefault(x => x.Id == entityId);
            return Task.FromResult(result);
        }

        public IQueryable<T> GetQueryableAllForAdmin()
        {
            return base.GetQueryableAll();
        }

        public override IQueryable<T> GetQueryableAll()
        {
            return base.GetQueryableAll().Where(x => x.Deleted == false);
        }

        public override Task DeleteAsync(T entity)
        {
            LogicalGuard.ExpectArgumentIsNotNull(() => entity);

            AuditDeleteDate(entity);
            return EntityRepository.Update(entity);
        }

        protected virtual void AuditDeleteDate(T entity)
        {
            entity.AuditDelete(DateTimeService, WorkContext);
        }
    }
}
