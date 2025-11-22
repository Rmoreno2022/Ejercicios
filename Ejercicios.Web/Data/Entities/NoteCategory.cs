namespace Ejercicios.Web.Data.Entities
{
    public class NoteCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Note>? Notes { get; set; }
    }
}
