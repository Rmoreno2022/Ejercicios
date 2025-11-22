using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Data.Abstractions
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task AddAsync(Reservation reservation);
        Task<bool> IsSlotTakenAsync(DateTime date, TimeSpan time);
    }
}
