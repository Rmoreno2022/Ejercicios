using Ejercicios.Web.DTOs;

namespace Ejercicios.Web.Services.Abstractions
{
    public interface IExpenseCategoryService
    {
        Task<IEnumerable<ExpenseCategoryDTO>> GetAllAsync();
    }
}
