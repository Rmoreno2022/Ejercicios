using AutoMapper;
using Ejercicios.Web.Data.Abstractions;
using Ejercicios.Web.DTOs;
using Ejercicios.Web.Services.Abstractions;
using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Services.Implementations
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _repo;
        private readonly IMapper _mapper;

        public SurveyService(ISurveyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<SurveyDTO>> GetAllAsync()
        {
            var surveys = await _repo.GetAllAsync();
            return _mapper.Map<List<SurveyDTO>>(surveys);
        }

        public async Task<SurveyDTO?> GetByIdAsync(int id)
        {
            var survey = await _repo.GetByIdAsync(id);
            return _mapper.Map<SurveyDTO>(survey);
        }

        public async Task CreateAsync(SurveyDTO dto)
        {
            // Map manual para evitar problemas con Votes
            var entity = new Survey
            {
                Title = dto.Title,
                Description = dto.Description,
                Options = dto.Options?.Select(o => new SurveyOption
                {
                    Text = o.Text
                }).ToList() ?? new List<SurveyOption>()
            };

            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(SurveyDTO dto)
        {
            var entity = new Survey
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Options = dto.Options?.Select(o => new SurveyOption
                {
                    Id = o.Id,
                    Text = o.Text
                }).ToList() ?? new List<SurveyOption>()
            };

            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task VoteAsync(int optionId)
        {
            await _repo.VoteAsync(optionId);
        }
    }
}
