using System;

namespace TodoWeb.Domain.Entities
{
    public class Todo : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsFinished { get; set; }

        public string ElapsedTime()
        {
            TimeSpan totalElapsedTime = DateTime.Now - CreatedAt;
            return $"{totalElapsedTime.Days} dias, {totalElapsedTime.Hours} horas e {totalElapsedTime.Minutes} minutos.";
        }
    }
}
