using Microsoft.EntityFrameworkCore;
using Ejercicios.Web.Data;
using Ejercicios.Web.Data.Abstractions;
using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Services.Implementations
{
    public class NotesRepository : INotesRepository
    {
        private readonly DataContext _context;

        public NotesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Note>> GetAllAsync(string? search)
        {
            var query = _context.Notes
                .Include(n => n.Category)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(n =>
                    n.Title.Contains(search) ||
                    n.Content.Contains(search));
            }

            return await query
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task<Note?> GetByIdAsync(int id)
        {
            return await _context.Notes
                .Include(n => n.Category)
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task AddAsync(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Note note)
        {
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }
    }
}
