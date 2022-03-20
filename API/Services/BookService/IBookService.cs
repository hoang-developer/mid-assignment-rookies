using API.Data.Entities;
using API.Models;

namespace API.Services.BookService
{

     public interface IBookService
    {
        public Task<IEnumerable<Book>> GetAllAsync();
        public Task<Book?> GetOneAsync(int id);
        public Task<ServiceResponse<Book?>> AddAsync(Book entity);
        public Task<Book?> EditAsync(Book entity);
        public Task<Book?> RemoveAsync(int id, Book entity);
        Task<ServiceResponse<List<Book>>> GetBooksByCategory(string categoryUrl);

    }
}