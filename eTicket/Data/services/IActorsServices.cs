using eTicket.Data.Base;
using eTicket.Models;

namespace eTicket.Data.services
{
    public interface IActorsServices
    {
        Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetByIdAsync(int id);
        Task AddAsync(Actor actor);
        Task<Actor> UpdateAsync(int id, Actor newActor);
        Task DeleteAsync(int id);
    }

    //public interface IActorsServices : IEntityBaseRespository<Actor>
    //{
    //}
}
