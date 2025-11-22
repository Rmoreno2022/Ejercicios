using Ejercicios.Web.Data.Abstractions;
using Ejercicios.Web.DTOs;
using Ejercicios.Web.Services.Abstractions;

namespace Ejercicios.Web.Services.Implementations
{
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly IExpenseCategoryRepository _repo;

        public ExpenseCategoryService(IExpenseCategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ExpenseCategoryDTO>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(c => new ExpenseCategoryDTO
            {
                Id = c.Id,
                Name = c.Name
            });
        }
    }
}
