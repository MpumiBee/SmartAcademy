using SmartAcademyBackend.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartAcademyBackend.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentSurname { get; set; } = string.Empty;
        public TeachingMode TeachingMode { get; set; }
        public Grade Grade { get; set; }
        //public Parent? Parent { get; set; }
        //public int ParentId { get; set; }
        public int? SubscriptionId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public bool IsStudentActive { get; set; }=true;
        public SubscriptionPlans? SubscriptionPlans { get; set; }
        public ICollection<Subjects> Subjects { get; set; } = new List<Subjects>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
