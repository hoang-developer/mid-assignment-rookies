using API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllIncludedAsync();
    }
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> GetAllIncludedAsync()
        {
            return await _entities.ToListAsync();
        }
    }
}