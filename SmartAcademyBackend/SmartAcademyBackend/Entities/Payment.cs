using SmartAcademyBackend.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartAcademyBackend.Entities
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int SubscriptionId { get; set; }
        public required SubscriptionPlans SubscriptionPlans { get; set; }
        public int StudentId { get; set; }
        public required Student Student { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    }
}
