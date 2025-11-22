using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Data.Abstractions
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEventsByDateAsync(DateTime date);
        Task<Event?> GetByIdAsync(int id);
        Task AddAsync(Event evt);
        Task UpdateAsync(Event evt);
        Task DeleteAsync(Event evt);
    }
}
