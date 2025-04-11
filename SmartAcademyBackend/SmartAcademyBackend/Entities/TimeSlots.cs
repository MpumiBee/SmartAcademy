using SmartAcademyBackend.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartAcademyBackend.Entities
{
    public class TimeSlots
    {
        [Key]
        public int TimeSlotId { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public DaysOfTheWeek DayOfWeek { get; set; }    

        public ICollection<TutorAvailability> TutorAvailabilities { get; set; } = new List<TutorAvailability>();
        
    }
}

