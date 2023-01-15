using Microsoft.EntityFrameworkCore;
using Products.Dal.Interfaces;
using Products.Domain;

namespace Products.Dal.Repositories
{
    public class EFCoreRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ProductsDbContext _context;

        public EFCoreRepository(ProductsDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
