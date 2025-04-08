using SmartAcademyBackend.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartAcademyBackend.Entities
{
    public class SubscriptionPlans
    {
        [Key]
        public int SubscriptionPlanId { get; set; }
        public string SubscriptionPlanName { get; set; } = string.Empty;
        public int NumberOfLessons { get; set; }
        public AttendanceType AttendanceType { get; set; }
        public TeachingMode TeachingMode { get; set; }
        public Student? student { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public decimal amount { get; set; }
        public bool isActive { get; set; } = true;
    }
}
