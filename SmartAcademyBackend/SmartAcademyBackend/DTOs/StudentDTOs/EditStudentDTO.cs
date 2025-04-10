using SmartAcademyBackend.Enums;

namespace SmartAcademyBackend.DTOs.StudentDTOs
{
    public record EditStudentDTO(string email,
        string StudentName,
        string StudentSurname,
        TeachingMode Teaching,
        Grade Grade,
        int? subscriptionId
        );
   
}
