using SmartAcademyBackend.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartAcademyBackend.Entities
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
        public int BookingId { get; set; }
        public required Booking Booking { get; set; }
        public AttendanceStatus AttendanceStatus { get; set; }
    }
}
