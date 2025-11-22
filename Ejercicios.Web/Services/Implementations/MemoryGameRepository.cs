using Microsoft.EntityFrameworkCore;
using Ejercicios.Web.Data;
using Ejercicios.Web.Data.Abstractions;
using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Services.Implementations
{
    public class MemoryGameRepository : IMemoryGameRepository
    {
        private readonly DataContext _context;

        public MemoryGameRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<MemoryCard>> GetAllCardsAsync()
        {
            return await _context.MemoryCards.ToListAsync();
        }

        public async Task SaveGameAsync(MemoryGame game)
        {
            _context.MemoryGames.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MemoryGame>> GetTopScoresAsync(int level)
        {
            return await _context.MemoryGames
                .Where(g => g.Level == level)
                .OrderBy(g => g.Moves)
                .ThenBy(g => g.TimeSeconds)
                .Take(10)
                .ToListAsync();
        }
    }
}
