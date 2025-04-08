using SmartAcademyBackend.Enums;

namespace SmartAcademyBackend.DTOs.SubscriptionDTOs
{
    public record EditSubscriptionPlanDTO(int NumberOfLessons,
        AttendanceType AttendanceType,
        TeachingMode TeachingMode,
        decimal amount,
        bool isActive,
        string subscriptionName
        );
}
