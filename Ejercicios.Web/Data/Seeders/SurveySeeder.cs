using Microsoft.EntityFrameworkCore;
using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Data.Seeders
{
    public class SurveySeeder
    {
        private readonly DataContext _context;

        public SurveySeeder(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (!await _context.Surveys.AnyAsync())
            {
                var s = new Survey
                {
                    Title = "¿Cuál es tu lenguaje favorito?",
                    Description = "Encuesta de prueba",
                    Options = new List<SurveyOption>
                    {
                        new SurveyOption { Text = "C#" },
                        new SurveyOption { Text = "JavaScript" },
                        new SurveyOption { Text = "Python" }
                    }
                };

                _context.Add(s);
                await _context.SaveChangesAsync();
            }
        }
    }
}
