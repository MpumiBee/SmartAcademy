using SmartAcademyBackend.Entities;
using SmartAcademyBackend.Enums;

namespace SmartAcademyBackend.DTOs.TutorDTO
{
    public record AddTutorDTO(string Email,
                            string TutorName,
                            string TutorSurname, 
                            string ContactNumber, 
                            string TutorBio,
                            TeachingMode TeachingMode,
                            List<int> SubjectID,
                            List<TutorAvailabilityDTO> TutorAvailability
                            );
   
}
