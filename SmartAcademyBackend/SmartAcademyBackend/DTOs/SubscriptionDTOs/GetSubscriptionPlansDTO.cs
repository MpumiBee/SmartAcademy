namespace SmartAcademyBackend.DTOs.SubscriptionDTOs
{
    public record GetSubscriptionPlansDTO(
         int subscriptionId,
         int NumberOfLessons,
         string AttendanceTypeName,
         string TeachingModeName,
         decimal amount
         );
}
