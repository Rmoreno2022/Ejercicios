using System;

namespace Ejercicios.Web.Data.Entities
{
    public class SurveyVote
    {
        public int Id { get; set; }

        public int SurveyOptionId { get; set; }
        public SurveyOption SurveyOption { get; set; }

        public DateTime VotedAt { get; set; } = DateTime.UtcNow;
    }
}
