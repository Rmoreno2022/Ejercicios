namespace Ejercicios.Web.DTOs
{
    public class SurveyDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public List<SurveyOptionDTO> Options { get; set; }
    }
}
