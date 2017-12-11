using OfficePlanApi.Domain.Entities;
using System.Linq;

namespace OfficePlanApi.Domain.Interfaces.Services
{
    public interface IBaseService<T> : IService<T>
        where T : BaseEntityAuditDate
    {
        IQueryable<T> GetQueryableAll();
    }
}
