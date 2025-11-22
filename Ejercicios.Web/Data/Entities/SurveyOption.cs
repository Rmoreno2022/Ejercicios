namespace Ejercicios.Web.Data.Entities
{
    public class SurveyOption
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        public ICollection<SurveyVote> Votes { get; set; }
    }
}
