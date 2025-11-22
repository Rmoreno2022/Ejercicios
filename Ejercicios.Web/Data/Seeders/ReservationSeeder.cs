using Ejercicios.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ejercicios.Web.Data.Seeders
{
    public class ReservationSeeder
    {
        private readonly DataContext _context;

        public ReservationSeeder(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (!await _context.Reservations.AnyAsync())
            {
                var reservations = new List<Reservation>
                {
                    new Reservation
                    {
                        CustomerName = "Juan Pérez",
                        ServiceName = "Corte de cabello",
                        Date = DateTime.Today.AddDays(1),
                        Time = new TimeSpan(10, 0, 0),
                        Status = "Confirmada"
                    },
                    new Reservation
                    {
                        CustomerName = "María López",
                        ServiceName = "Consulta médica",
                        Date = DateTime.Today.AddDays(2),
                        Time = new TimeSpan(14, 30, 0),
                        Status = "Confirmada"
                    },
                    new Reservation
                    {
                        CustomerName = "Carlos Torres",
                        ServiceName = "Spa masaje",
                        Date = DateTime.Today.AddDays(3),
                        Time = new TimeSpan(9, 0, 0),
                        Status = "Confirmada"
                    }
                };

                _context.Reservations.AddRange(reservations);
                await _context.SaveChangesAsync();
            }
        }
    }
}
