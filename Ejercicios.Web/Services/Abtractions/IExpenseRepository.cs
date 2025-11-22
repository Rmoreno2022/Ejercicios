using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Data.Abstractions
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetAllAsync();
        Task AddAsync(Expense expense);
        Task<IEnumerable<Expense>> GetByMonthAsync(int year, int month);
    }
}
