using Ejercicios.Web.DTOs;

namespace Ejercicios.Web.Services.Abstractions
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDTO>> GetAllAsync();
        Task<bool> CreateAsync(ReservationDTO dto);
    }
}
