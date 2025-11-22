using Ejercicios.Web.DTOs;
using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Services.Abstractions
{
    public interface IMemoryGameService
    {
        Task<List<MemoryCardDTO>> GetCardsAsync();
        Task SaveGameAsync(MemoryGameDTO dto, string userId);
        Task<List<MemoryGame>> GetTopScoresAsync(int level);
    }
}
