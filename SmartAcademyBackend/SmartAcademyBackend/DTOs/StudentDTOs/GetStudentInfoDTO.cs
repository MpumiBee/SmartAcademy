using SmartAcademyBackend.DTOs.SubscriptionDTOs;
using SmartAcademyBackend.Entities;

namespace SmartAcademyBackend.DTOs.StudentDTOs
{
    public record class GetStudentInfoDTO(
        int studentId,
        string fullName,
        string email,
        string teachMode,
        string grade,
        string parentFullName,
        string parentEmail,
        GetSubscriptionPlansDTO? subscriptionPlan
     
        );
    
}
