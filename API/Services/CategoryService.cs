using API.Data.Entities;
using API.Data.Repositories;

namespace API.Services
{
    public interface ICategoryService
    {
        public Task<IList<Category>> GetAllAsync();
        public Task<Category?> GetOneAsync(int id);
        public Task<Category?> AddAsync(Category entity);
        public Task<Category?> EditAsync(Category entity);
        public Task<Category?> RemoveAsync(int id, Category entity);

    }
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category?> AddAsync(Category entity)
        {
            await _repository.InsertAsync(entity);

            return entity;
        }

        public async Task<Category?> EditAsync(Category entity)
        {
            await _repository.UpdateAsync(entity);

            return entity;
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            var data = await _repository.GetAllIncludedAsync();
            return data.ToList();
        }

        public async Task<Category?> GetOneAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Category?> RemoveAsync(int id, Category entity)
        {
            if (_repository == null) return null;

            var entityId = await _repository.GetAsync(id);
             await _repository.DeleteAsync(entity);
             return entity;
        }
    }


}