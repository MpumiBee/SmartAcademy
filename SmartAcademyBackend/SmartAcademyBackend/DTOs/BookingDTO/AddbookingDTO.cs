using SmartAcademyBackend.Enums;

namespace SmartAcademyBackend.DTOs.BookingDTO
{
    public record AddbookingDTO(int StudentId,
                                 int TutorId,
                                 int SubjectId,
                                 int tutorAvailabilityId,
                                 AttendanceType AttendanceType,
                                 DateOnly sessionDate

        );
    
}
