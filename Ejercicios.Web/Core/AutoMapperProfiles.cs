using AutoMapper;
using Ejercicios.Web.Data.Entities;
using Ejercicios.Web.DTOs;

namespace Ejercicios.Web.Core.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
          
            // 🔁 Otros mapeos si existen
           
            CreateMap<TaskItem, TaskItemDTO>().ReverseMap();
            CreateMap<NoteCategory, NoteCategoryDTO>().ReverseMap();
            CreateMap<Note, NoteDTO>().ReverseMap();
            CreateMap<ExpenseCategory, ExpenseCategoryDTO>().ReverseMap();
            CreateMap<Expense, ExpenseDTO>().ReverseMap();
            CreateMap<Reservation, ReservationDTO>().ReverseMap();
            CreateMap<Recipe, RecipeDTO>().ReverseMap();
            CreateMap<RecipeCategory, RecipeCategoryDTO>().ReverseMap();
            // Mapeo para Event y EventDTO
            CreateMap<Event, EventDTO>().ReverseMap();

            CreateMap<MemoryGame, MemoryGameDTO>().ReverseMap();
            CreateMap<MemoryCard, MemoryCardDTO>().ReverseMap();

            CreateMap<Survey, SurveyDTO>().ReverseMap();
            CreateMap<SurveyOption, SurveyOptionDTO>()
        .ForMember(d => d.Votes, opt => opt.MapFrom(s => s.Votes.Count));


        }
    }
}
