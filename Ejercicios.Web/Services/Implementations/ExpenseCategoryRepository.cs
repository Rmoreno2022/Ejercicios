using Microsoft.EntityFrameworkCore;
using Ejercicios.Web.Data;
using Ejercicios.Web.Data.Abstractions;
using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Services.Implementations
{
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        private readonly DataContext _context;

        public ExpenseCategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExpenseCategory>> GetAllAsync()
        {
            return await _context.ExpenseCategories
                .OrderBy(c => c.Name)
                .ToListAsync();
        }
    }
}
