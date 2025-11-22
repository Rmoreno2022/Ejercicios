using Ejercicios.Web.Data.Abstractions;
using Ejercicios.Web.Data.Entities;
using Ejercicios.Web.DTOs;
using Ejercicios.Web.Services.Abstractions;

namespace Ejercicios.Web.Services.Implementations
{
    public class NotesService : INotesService
    {
        private readonly INotesRepository _repo;

        public NotesService(INotesRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<NoteDTO>> GetAllAsync(string? search)
        {
            var notes = await _repo.GetAllAsync(search);

            return notes.Select(n => new NoteDTO
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content,
                NoteCategoryId = n.NoteCategoryId,
                CategoryName = n.Category?.Name,
                CreatedAt = n.CreatedAt
            });
        }

        public async Task<NoteDTO?> GetByIdAsync(int id)
        {
            var n = await _repo.GetByIdAsync(id);
            if (n == null) return null;

            return new NoteDTO
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content,
                NoteCategoryId = n.NoteCategoryId,
                CategoryName = n.Category?.Name,
                CreatedAt = n.CreatedAt
            };
        }

        public async Task CreateAsync(NoteDTO dto)
        {
            var note = new Note
            {
                Title = dto.Title,
                Content = dto.Content,
                NoteCategoryId = dto.NoteCategoryId
            };

            await _repo.AddAsync(note);
        }

        public async Task UpdateAsync(NoteDTO dto)
        {
            var entity = await _repo.GetByIdAsync(dto.Id);
            if (entity == null) return;

            entity.Title = dto.Title;
            entity.Content = dto.Content;
            entity.NoteCategoryId = dto.NoteCategoryId;

            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var note = await _repo.GetByIdAsync(id);
            if (note != null)
                await _repo.DeleteAsync(note);
        }
    }
}
