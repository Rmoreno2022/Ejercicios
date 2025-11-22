using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Data.Abstractions
{
    public interface ISurveyRepository
    {
        Task<List<Survey>> GetAllAsync();
        Task<Survey?> GetByIdAsync(int id);
        Task AddAsync(Survey survey);
        Task UpdateAsync(Survey survey);
        Task DeleteAsync(int id);

        Task VoteAsync(int optionId);
        Task SaveChangesAsync();
    }
}

