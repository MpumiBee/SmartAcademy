using SmartAcademyBackend.Enums;

namespace SmartAcademyBackend.DTOs.BookingDTO
{
    public record GetBookingDTO(int BookingId,
                                  string StudentFullName,
                                  string StudentEmail,
                                  string TutorFullName,
                                 // string TutorEmail,
                                  //string SubjectName,
                                  DateOnly SessionDate,
                                  TimeOnly StartTime,
                                  TimeOnly EndTime,
                                  string DayOfWeek,
                                  string AttendanceType,
                                  string TeachingMode,
                                  string BookingStatus
  );

}
