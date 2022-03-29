using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BetStackApp.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> ListAllAsync();  // was IreadonlyList<T>
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetListByIdsAsync(List<Guid> listId); // when implemented need to make sure context returns BC prop BetOn

        Task<List<T>> GetListByIdAsync( Guid id);
    }
}
