using Ejercicios.Web.Services.Abstractions;
using Ejercicios.Web.Data.Abstractions;
using Ejercicios.Web.DTOs;
using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repo;

        public TaskService(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TaskItemDTO>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return items.Select(t => new TaskItemDTO
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
                CreatedAt = t.CreatedAt
            });
        }

        public async Task<TaskItemDTO?> GetByIdAsync(int id)
        {
            var t = await _repo.GetByIdAsync(id);
            if (t == null) return null;

            return new TaskItemDTO
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
                CreatedAt = t.CreatedAt
            };
        }

        public async Task CreateAsync(TaskItemDTO dto)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow,
                IsCompleted = false
            };

            await _repo.AddAsync(task);
        }

        public async Task UpdateAsync(TaskItemDTO dto)
        {
            var t = await _repo.GetByIdAsync(dto.Id);
            if (t == null) return;

            t.Title = dto.Title;
            t.Description = dto.Description;

            await _repo.UpdateAsync(t);
        }

        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);

        public async Task ToggleCompleteAsync(int id)
        {
            var t = await _repo.GetByIdAsync(id);
            if (t == null) return;

            t.IsCompleted = !t.IsCompleted;
            await _repo.UpdateAsync(t);
        }
    }
}
