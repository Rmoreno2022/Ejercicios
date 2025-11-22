namespace Ejercicios.Web.Data.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string ServiceName { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public string Status { get; set; } = "Confirmada";
    }
}
