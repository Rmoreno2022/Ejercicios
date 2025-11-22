using Ejercicios.Web.Data;
using Ejercicios.Web.Data.Entities;

public class NoteCategorySeeder
{
    private readonly DataContext _context;

    public NoteCategorySeeder(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        if (!_context.NoteCategories.Any())
        {
            _context.NoteCategories.AddRange(
                new NoteCategory { Name = "Personal" },
                new NoteCategory { Name = "Trabajo" },
                new NoteCategory { Name = "Ideas" },
                new NoteCategory { Name = "Estudio" }
            );

            await _context.SaveChangesAsync();
        }
    }
}
