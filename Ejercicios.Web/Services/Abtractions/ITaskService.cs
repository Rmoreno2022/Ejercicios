using Ejercicios.Web.DTOs;

namespace Ejercicios.Web.Services.Abstractions
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItemDTO>> GetAllAsync();
        Task<TaskItemDTO?> GetByIdAsync(int id);
        Task CreateAsync(TaskItemDTO dto);
        Task UpdateAsync(TaskItemDTO dto);
        Task DeleteAsync(int id);
        Task ToggleCompleteAsync(int id);
    }
}
