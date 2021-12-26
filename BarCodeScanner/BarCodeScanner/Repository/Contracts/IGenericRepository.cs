using BarCodeScanner.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarCodeScanner.Repository.Contracts
{
    public interface IGenericRepository<T, T1> where T : IEntity<T1>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(T1 id);
        Task<T> InsertAsync(T entity);
        Task<IEnumerable<T>> InsertAllAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<IEnumerable<T>> UpdateAllAsync(IEnumerable<T> entities);
        Task<bool> DeleteAsync(T1 id);
        Task<bool> DeleteAllAsync(T1[] ids);
    }
}
