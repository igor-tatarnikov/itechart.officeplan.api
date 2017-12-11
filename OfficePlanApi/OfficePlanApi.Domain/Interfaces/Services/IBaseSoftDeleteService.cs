using OfficePlanApi.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace OfficePlanApi.Domain.Interfaces.Services
{
    public interface IBaseSoftDeleteService<T> : IBaseService<T>
        where T: BaseEntitySoftDelete
    {
        Task<T> GetByIdAsync(int entityId, bool allowDeleted);

        IQueryable<T> GetQueryableAllForAdmin();
    }
}
