using Ejercicios.Web.Data.Abstractions;
using Ejercicios.Web.Data.Entities;
using Ejercicios.Web.DTOs;
using Ejercicios.Web.Services.Abstractions;

namespace Ejercicios.Web.Services.Implementations
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repo;

        public ExpenseService(IExpenseRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ExpenseDTO>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();

            return list.Select(e => new ExpenseDTO
            {
                Id = e.Id,
                Amount = e.Amount,
                Date = e.Date,
                Description = e.Description,
                CategoryId = e.CategoryId,
                CategoryName = e.Category?.Name
            });
        }

        public async Task AddAsync(ExpenseDTO dto)
        {
            var expense = new Expense
            {
                Amount = dto.Amount,
                Description = dto.Description,
                Date = dto.Date,
                CategoryId = dto.CategoryId
            };

            await _repo.AddAsync(expense);
        }

        public async Task<IEnumerable<ExpenseDTO>> GetMonthlyAsync(int year, int month)
        {
            var list = await _repo.GetByMonthAsync(year, month);

            return list.Select(e => new ExpenseDTO
            {
                Id = e.Id,
                Amount = e.Amount,
                Description = e.Description,
                Date = e.Date,
                CategoryName = e.Category!.Name
            });
        }
    }
}
