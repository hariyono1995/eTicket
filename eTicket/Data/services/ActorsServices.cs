using eTicket.Data.Base;
using eTicket.Models;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Data.services
{
    public class ActorsServices : IActorsServices
    {
        private readonly AppDbContext _context;

        public ActorsServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Actor actor)
        {
            await _context.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
            _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
            return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }
    }

    //public class ActorService : EntityBaseRespository<Actor>, IActorServices
    //{

    //}
}
