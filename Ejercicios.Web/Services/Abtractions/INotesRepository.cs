using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Data.Abstractions
{
    public interface INotesRepository
    {
        Task<IEnumerable<Note>> GetAllAsync(string? search);
        Task<Note?> GetByIdAsync(int id);
        Task AddAsync(Note note);
        Task UpdateAsync(Note note);
        Task DeleteAsync(Note note);
    }
}
