using SmartAcademyBackend.Enums;

namespace SmartAcademyBackend.DTOs.TutorDTO
{
    public class TutorAvailabilityDTO
    {
        public required DaysOfTheWeek Day { get; set; }
        public int TimeSlotId { get; set; }
    }
}
