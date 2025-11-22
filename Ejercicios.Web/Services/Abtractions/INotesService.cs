using Ejercicios.Web.DTOs;

namespace Ejercicios.Web.Services.Abstractions
{
    public interface INotesService
    {
        Task<IEnumerable<NoteDTO>> GetAllAsync(string? search);
        Task<NoteDTO?> GetByIdAsync(int id);
        Task CreateAsync(NoteDTO dto);
        Task UpdateAsync(NoteDTO dto);
        Task DeleteAsync(int id);
    }
}
