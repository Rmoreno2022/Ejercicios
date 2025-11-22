using Microsoft.EntityFrameworkCore;
using Ejercicios.Web.Data.Abstractions;
using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Data
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly DataContext _context;

        public SurveyRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Survey>> GetAllAsync()
        {
            return await _context.Surveys.Include(s => s.Options).ToListAsync();
        }

        public async Task<Survey?> GetByIdAsync(int id)
        {
            return await _context.Surveys
                .Include(s => s.Options)
                .ThenInclude(o => o.Votes)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Survey survey)
        {
            _context.Add(survey);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Survey survey)
        {
            _context.Update(survey);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var survey = await GetByIdAsync(id);
            if (survey == null) return;

            _context.Remove(survey);
            await _context.SaveChangesAsync();
        }

        public async Task VoteAsync(int optionId)
        {
            var vote = new SurveyVote
            {
                SurveyOptionId = optionId
            };

            _context.SurveyVotes.Add(vote);
            await _context.SaveChangesAsync();
        }

        public Task SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
