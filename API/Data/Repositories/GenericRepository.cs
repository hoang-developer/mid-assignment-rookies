using API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        protected DbSet<T> _entities;
        public GenericRepository(DataContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _entities.Where(x => x.Id == id).FirstOrDefaultAsync(); 
        }

        public async Task<T> InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await _context.Database.BeginTransactionAsync();
            try
            {
                await _entities.AddAsync(entity);
                await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();
            }
            catch (System.Exception)
            {
                await _context.Database.RollbackTransactionAsync();
            }
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            // if (entity == null)
            // {
            //     throw new ArgumentNullException("entity");
            // }
            // await _context.Database.BeginTransactionAsync();

            // try
            // {
                _entities.Update(entity);
                await _context.SaveChangesAsync();
            // }
            // catch (System.Exception)
            // {
            //     await _context.Database.RollbackTransactionAsync();

            // }
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await _context.Database.BeginTransactionAsync();

            try
            {
                _entities.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                await _context.Database.RollbackTransactionAsync();
            }
        }
    }
}