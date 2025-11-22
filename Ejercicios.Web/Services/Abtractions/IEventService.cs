using Ejercicios.Web.DTOs;

namespace Ejercicios.Web.Services.Abstractions
{
    public interface IEventService
    {
        Task<IEnumerable<EventDTO>> GetEventsByDateAsync(DateTime date);
        Task<EventDTO?> GetByIdAsync(int id);
        Task CreateAsync(EventDTO dto);
        Task UpdateAsync(EventDTO dto);
        Task DeleteAsync(int id);
    }
}
