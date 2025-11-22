using Microsoft.EntityFrameworkCore;
using Ejercicios.Web.Data;
using Ejercicios.Web.Data.Abstractions;
using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Services.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _db;
        public TaskRepository(DataContext db) => _db = db;

        public async Task AddAsync(TaskItem task)
        {
            await _db.TaskItems.AddAsync(task);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var e = await _db.TaskItems.FindAsync(id);
            if (e != null)
            {
                _db.TaskItems.Remove(e);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _db.TaskItems
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _db.TaskItems.FindAsync(id);
        }

        public async Task UpdateAsync(TaskItem task)
        {
            _db.TaskItems.Update(task);
            await _db.SaveChangesAsync();
        }
    }
}
