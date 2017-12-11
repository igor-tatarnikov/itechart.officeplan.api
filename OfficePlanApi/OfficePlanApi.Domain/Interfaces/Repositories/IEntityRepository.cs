using OfficePlanApi.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace OfficePlanApi.Domain.Interfaces.Repositories
{
    public interface IEntityRepository<T>
        where T : BaseEntity
    {
        IQueryable<T> GetAll();

        Task Create(T entity);

        Task Update(T entity);

        Task Delete(T entity);
    }
}
