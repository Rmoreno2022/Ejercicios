using Ejercicios.Web.DTOs;

namespace Ejercicios.Web.Services.Abstractions
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseDTO>> GetAllAsync();
        Task AddAsync(ExpenseDTO dto);
        Task<IEnumerable<ExpenseDTO>> GetMonthlyAsync(int year, int month);
    }
}
