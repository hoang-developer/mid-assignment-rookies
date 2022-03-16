using API.Data.Entities;

namespace API.Data.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
         Task<IEnumerable<T>> GetAllAsync();
         Task<T?> GetAsync(int id);
         Task<T> InsertAsync(T entity);
         Task<T> UpdateAsync(T entity);
         Task DeleteAsync(T entity);
    }
}