using SmartAcademyBackend.Enums;

namespace SmartAcademyBackend.DTOs.TutorDTO
{
    public record GetTutorAvailabilitySlots(string DayOfWeek, TimeOnly StartTime, TimeOnly EndTime);
   
}
