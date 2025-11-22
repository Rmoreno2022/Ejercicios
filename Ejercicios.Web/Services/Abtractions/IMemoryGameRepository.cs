using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Data.Abstractions
{
    public interface IMemoryGameRepository
    {
        Task<List<MemoryCard>> GetAllCardsAsync();
        Task SaveGameAsync(MemoryGame game);
        Task<List<MemoryGame>> GetTopScoresAsync(int level);
    }
}
