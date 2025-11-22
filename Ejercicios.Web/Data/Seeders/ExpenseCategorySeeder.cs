using Ejercicios.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ejercicios.Web.Data.Seeders
{
    public class ExpenseCategorySeeder
    {
        private readonly DataContext _context;

        public ExpenseCategorySeeder(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (!await _context.ExpenseCategories.AnyAsync())
            {
                var categories = new List<ExpenseCategory>
                {
                    new ExpenseCategory { Name = "Alimentación" },
                    new ExpenseCategory { Name = "Transporte" },
                    new ExpenseCategory { Name = "Salud" },
                    new ExpenseCategory { Name = "Entretenimiento" },
                    new ExpenseCategory { Name = "Hogar" },
                    new ExpenseCategory { Name = "Educación" },
                    new ExpenseCategory { Name = "Varios" }
                };

                _context.ExpenseCategories.AddRange(categories);
                await _context.SaveChangesAsync();
            }
        }
    }
}
