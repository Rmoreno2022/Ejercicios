using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Data.Abstractions
{
    public interface IExpenseCategoryRepository
    {
        Task<IEnumerable<ExpenseCategory>> GetAllAsync();
    }
}
