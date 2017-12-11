using OfficePlanApi.Domain.Entities;
using OfficePlanApi.Domain.Extensions;
using OfficePlanApi.Domain.Helpers;
using OfficePlanApi.Domain.Interfaces.Repositories;
using OfficePlanApi.Domain.Interfaces.Services;
using OfficePlanApi.Domain.Interfaces.WorkContexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficePlanApi.BLL.Services
{
    public class BaseService<T> : IBaseService<T>
        where T : BaseEntityAuditDate
    {
        private readonly IEntityRepository<T> _repository;
        private readonly IBaseWorkContext _workContext;
        private readonly IDateTimeService _dateTimeService;

        public BaseService(
            IEntityRepository<T> repository,
            IBaseWorkContext workContext,
            IDateTimeService dateTimeService)
        {
            _repository = repository;
            _workContext = workContext;
            _dateTimeService = dateTimeService;
        }

        protected IEntityRepository<T> EntityRepository
        {
            get { return _repository; }
        }

        protected IDateTimeService DateTimeService
        {
            get { return _dateTimeService; }
        }

        protected IBaseWorkContext WorkContext
        {
            get { return _workContext; }
        }

        public virtual IList<T> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public virtual IQueryable<T> GetQueryableAll()
        {
            return _repository.GetAll();
        }

        public virtual Task<T> GetByIdAsync(int id)
        {
            var result = GetQueryableAll().SingleOrDefault(x => x.Id == id);
            return Task.FromResult(result);
        }

        public virtual Task CreateAsync(T entity)
        {
            LogicalGuard.ExpectArgumentIsNotNull(() => entity);

            AuditCreateDate(entity);
            return _repository.Create(entity);
        }

        public virtual Task UpdateAsync(T entity)
        {
            LogicalGuard.ExpectArgumentIsNotNull(() => entity);

            AuditModifyDate(entity);
            return _repository.Update(entity);
        }

        public virtual Task DeleteAsync(T entity)
        {
            LogicalGuard.ExpectArgumentIsNotNull(() => entity);

            return _repository.Delete(entity);
        }

        protected virtual void AuditCreateDate(T entity)
        {
            entity.AuditCreate(_dateTimeService, _workContext);
        }

        protected virtual void AuditModifyDate(T entity)
        {
            entity.AuditModify(_dateTimeService, _workContext);
        }
    }
}
