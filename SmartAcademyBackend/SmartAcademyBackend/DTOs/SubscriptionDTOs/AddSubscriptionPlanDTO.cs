using SmartAcademyBackend.Enums;

namespace SmartAcademyBackend.DTOs.SubscriptionDTOs
{
    public record AddSubscriptionPlanDTO(string SubscriptionPlanName,
                                       int NumberOfLessons,
                                       AttendanceType AttendanceType,
                                       TeachingMode TeachingMode,
                                       decimal amount

        );
}
