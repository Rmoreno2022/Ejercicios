using Microsoft.EntityFrameworkCore;
using Ejercicios.Web.Data;
using Ejercicios.Web.Data.Abstractions;
using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Services.Implementations
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly DataContext _context;

        public ExpenseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expense>> GetAllAsync()
        {
            return await _context.Expenses
                .Include(e => e.Category)
                .OrderByDescending(e => e.Date)
                .ToListAsync();
        }

        public async Task AddAsync(Expense expense)
        {
            _context.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> GetByMonthAsync(int year, int month)
        {
            return await _context.Expenses
                .Include(e => e.Category)
                .Where(e => e.Date.Year == year && e.Date.Month == month)
                .OrderByDescending(e => e.Date)
                .ToListAsync();
        }
    }
}
