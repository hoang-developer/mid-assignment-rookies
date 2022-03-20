using API.Data;
using API.Data.Entities;
using API.Data.Repositories;
using API.Models;
using API.Services.BookService;
using Microsoft.EntityFrameworkCore;

namespace API.Services.BookService
{

    public class BookService : IBookService
    {
        private readonly DataContext _context;
        private readonly IBookRepository _repository;
        public BookService(IBookRepository repository, DataContext context)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<ServiceResponse<Book?>> AddAsync(Book entity)
        {
            await _repository.InsertAsync(entity);

            return new ServiceResponse<Book?> { Data = entity };
        }

        public async Task<Book?> EditAsync(Book entity)
        {
            await _repository.UpdateAsync(entity);

            return entity;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
           var data = await _repository.GetAllIncludedAsync();
            return data.ToList();
        }

        public async Task<ServiceResponse<List<Book>>> GetBooksByCategory(string Name)
        {
            var response = new ServiceResponse<List<Book>>
            {
                Data = await _context.Books
                    .Where(p => p.Category.Name.ToLower().Equals(Name.ToLower()))
                    .ToListAsync()
            };
            return response;
        }

        public async Task<Book?> GetOneAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Book?> RemoveAsync(int id, Book entity)
        {
            if (_repository == null) return null;

            var entityId = await _repository.GetAsync(id);
             await _repository.DeleteAsync(entity);
             return entity;
        }
    }

}