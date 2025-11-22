using AutoMapper;
using Ejercicios.Web.Data.Abstractions;
using Ejercicios.Web.Data.Entities;
using Ejercicios.Web.DTOs;
using Ejercicios.Web.Services.Abstractions;

namespace Ejercicios.Web.Services.Implementations
{
    public class MemoryGameService : IMemoryGameService
    {
        private readonly IMemoryGameRepository _repo;
        private readonly IMapper _mapper;

        public MemoryGameService(IMemoryGameRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<MemoryCardDTO>> GetCardsAsync()
        {
            var cards = await _repo.GetAllCardsAsync();
            return _mapper.Map<List<MemoryCardDTO>>(cards);
        }

        public async Task SaveGameAsync(MemoryGameDTO dto, string userId)
        {
            MemoryGame game = new MemoryGame
            {
                Level = dto.Level,
                Moves = dto.Moves,
                TimeSeconds = dto.TimeSeconds,
                UserId = userId,
                PlayedAt = DateTime.UtcNow
            };

            await _repo.SaveGameAsync(game);
        }

        public async Task<List<MemoryGame>> GetTopScoresAsync(int level)
        {
            return await _repo.GetTopScoresAsync(level);
        }
    }
}
