using SmartAcademyBackend.DTOs.TutorDTO;
using SmartAcademyBackend.Entities;

namespace SmartAcademyBackend.Service.TutorService
{
    public interface ITutorService
    {
        Task<Tutor?> addNewTutor(AddTutorDTO addTutor);
        Task<GetTutorInfoDTO?> getTutorById(int id);
    }
}
