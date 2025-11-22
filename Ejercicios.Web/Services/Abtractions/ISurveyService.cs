using Ejercicios.Web.DTOs;

namespace Ejercicios.Web.Services.Abstractions
{
    public interface ISurveyService
    {
        Task<List<SurveyDTO>> GetAllAsync();
        Task<SurveyDTO?> GetByIdAsync(int id);
        Task CreateAsync(SurveyDTO dto);
        Task UpdateAsync(SurveyDTO dto);
        Task DeleteAsync(int id);

        Task VoteAsync(int optionId);
    }
}
