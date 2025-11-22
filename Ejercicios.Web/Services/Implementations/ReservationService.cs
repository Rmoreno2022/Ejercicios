using Ejercicios.Web.Data.Abstractions;
using Ejercicios.Web.Data.Entities;
using Ejercicios.Web.DTOs;
using Ejercicios.Web.Services.Abstractions;

namespace Ejercicios.Web.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _repo;

        public ReservationService(IReservationRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ReservationDTO>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();

            return list.Select(r => new ReservationDTO
            {
                Id = r.Id,
                CustomerName = r.CustomerName,
                ServiceName = r.ServiceName,
                Date = r.Date,
                Time = r.Time,
                Status = r.Status
            });
        }

        public async Task<bool> CreateAsync(ReservationDTO dto)
        {
            // validar disponibilidad
            if (await _repo.IsSlotTakenAsync(dto.Date, dto.Time))
                return false;

            var reservation = new Reservation
            {
                CustomerName = dto.CustomerName,
                ServiceName = dto.ServiceName,
                Date = dto.Date,
                Time = dto.Time,
                Status = "Confirmada"
            };

            await _repo.AddAsync(reservation);

            return true;
        }
    }
}
