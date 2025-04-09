using SmartAcademyBackend.DTOs.ParentDTO;
using SmartAcademyBackend.Entities;
using SmartAcademyBackend.Enums;

namespace SmartAcademyBackend.DTOs.StudentDTOs
{
    public record AddStudentDTO(string StudentName,
                                string StudentSurname,
                                string Email, 
                                TeachingMode TeachingMode, 
                                Grade Grade,
                                AddParentDTO Parent, 
                                int? SubscriptionId);
    
}
