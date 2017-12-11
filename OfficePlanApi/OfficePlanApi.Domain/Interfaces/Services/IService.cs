using OfficePlanApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficePlanApi.Domain.Interfaces.Services
{
    public interface IService<T>
    {
        IList<T> GetAll();

        Task<T> GetByIdAsync(int id);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
