namespace Ejercicios.Web.Data.Entities
{
    public class MemoryGame
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime PlayedAt { get; set; } = DateTime.UtcNow;

        // Nivel del juego: 1 = fácil, 2 = medio, 3 = difícil
        public int Level { get; set; }

        // Cantidad de movimientos realizados
        public int Moves { get; set; }

        // Tiempo total en segundos
        public int TimeSeconds { get; set; }
    }
}
