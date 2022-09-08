using eTicket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eTicket.Data.Base
{
    public class EntityBaseRespository<T> : IEntityBaseRespository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;

        public EntityBaseRespository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity) => await _context.AddAsync(entity);

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();


        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
        }
    }
}
