using System;
using System.Collections.Generic;

namespace Ejercicios.Web.Data.Entities
{
    public class Survey
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<SurveyOption> Options { get; set; } = new List<SurveyOption>();
    }
}
