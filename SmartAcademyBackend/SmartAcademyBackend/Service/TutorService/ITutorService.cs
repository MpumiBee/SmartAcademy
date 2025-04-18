using SmartAcademyBackend.DTOs.TutorDTO;
using SmartAcademyBackend.Entities;

namespace SmartAcademyBackend.Service.TutorService
{
    public interface ITutorService
    {
        Task<Tutor?> addNewTutor(AddTutorDTO addTutor,int userId);
        Task<GetTutorInfoDTO?> getTutorById(int id);
        Task<List<GetTutorInfoDTO>?> getAllTutors();
    }
}
