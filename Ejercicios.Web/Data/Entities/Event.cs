using System;

namespace Ejercicios.Web.Data.Entities
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool HasReminder { get; set; }

        public DateTime? ReminderDate { get; set; }
    }
}
