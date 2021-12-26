using BarCodeScanner.Repository.Contracts;
using BarCodeScanner.Repository.Entities;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarCodeScanner.Repository
{
    public class GenericRepository<T, T1> : IGenericRepository<T, T1> where T : IEntity<T1>, new()
    {
        private readonly SQLiteAsyncConnection _connection;

        public GenericRepository(SQLiteAsyncConnection connection)
        {
            _connection = connection;
        }

        public Task<List<T>> GetAllAsync()
        {
            return _connection.Table<T>().ToListAsync();
        }

        public Task<T> GetByIdAsync(T1 id)
        {
            return _connection.Table<T>().Where(i => i.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<T> InsertAsync(T entity)
        {
            await _connection.InsertAsync(entity, typeof(T));

            return entity;
        }

        public async Task<IEnumerable<T>> InsertAllAsync(IEnumerable<T> entities)
        {
            await _connection.InsertAllAsync(entities, typeof(T));

            return entities;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await _connection.UpdateAsync(entity, typeof(T));

            return entity;
        }

        public async Task<IEnumerable<T>> UpdateAllAsync(IEnumerable<T> entities)
        {
            await _connection.UpdateAllAsync(entities);

            return entities;
        }

        public async Task<bool> DeleteAsync(T1 id)
        {
            int result = await _connection.DeleteAsync<T>(id);

            return result.Equals(1);
        }

        public async Task<bool> DeleteAllAsync(T1[] ids)
        {
            int result = 0;

            foreach (var _id in ids)
            {
                result += await _connection.DeleteAsync<T>(_id);
            }

            return result.Equals(ids.Length);
        }
    }
}
