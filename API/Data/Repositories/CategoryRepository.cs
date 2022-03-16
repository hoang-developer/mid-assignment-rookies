using API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllIncludedAsync();
    }
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetAllIncludedAsync()
        {
            return await _entities.Include(c => c.Books).ToListAsync();
        }
    }
}