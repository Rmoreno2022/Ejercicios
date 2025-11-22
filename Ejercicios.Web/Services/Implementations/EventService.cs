using AutoMapper;
using Ejercicios.Web.Data.Abstractions;
using Ejercicios.Web.Data.Entities;
using Ejercicios.Web.DTOs;
using Ejercicios.Web.Services.Abstractions;

namespace Ejercicios.Web.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repo;
        private readonly IMapper _mapper;

        public EventService(IEventRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventDTO>> GetEventsByDateAsync(DateTime date)
        {
            var events = await _repo.GetEventsByDateAsync(date);
            return _mapper.Map<IEnumerable<EventDTO>>(events);
        }

        public async Task<EventDTO?> GetByIdAsync(int id)
        {
            var evt = await _repo.GetByIdAsync(id);
            return _mapper.Map<EventDTO?>(evt);
        }

        public async Task CreateAsync(EventDTO dto)
        {
            var evt = _mapper.Map<Event>(dto);
            await _repo.AddAsync(evt);
        }

        public async Task UpdateAsync(EventDTO dto)
        {
            var evt = await _repo.GetByIdAsync(dto.Id);
            if (evt == null) return;

            _mapper.Map(dto, evt);

            await _repo.UpdateAsync(evt);
        }

        public async Task DeleteAsync(int id)
        {
            var evt = await _repo.GetByIdAsync(id);
            if (evt != null)
                await _repo.DeleteAsync(evt);
        }
    }
}
