using SmartAcademyBackend.Enums;

namespace SmartAcademyBackend.DTOs.TutorDTO
{
    public record GetTutorInfoDTO(int TutorId,
                            string TutorName,
                            string TutorSurname,
                            string ContactNumber,
                            string TutorBio,
                            string TeachingMode,
                            List<GetSubjectsDTO> subjects,
                            List<GetTutorAvailabilitySlots> TutorAvailabilities
        );
    
}
