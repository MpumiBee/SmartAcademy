using SmartAcademyBackend.Entities;
using SmartAcademyBackend.Enums;

namespace SmartAcademyBackend.DTOs.StudentDTOs
{
    public record AddStudentDTO(string StudentName,
                                string StudentSurname,
                                string Email, 
                                TeachingMode TeachingMode, 
                                Grade Grade,
                                Parent Parent, 
                                int? SubscriptionId);
    
}
