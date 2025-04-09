using SmartAcademyBackend.DTOs.StudentDTOs;
using SmartAcademyBackend.Entities;

namespace SmartAcademyBackend.Service.StudentService
{
    public interface IStudentService
    {
        public Task<Student?> addNewStudent(AddStudentDTO newStudent);
        public Task<List<GetStudentInfoDTO>> getAllStudentInformation();
        public Task<GetStudentInfoDTO?> getStudentInformationById(int studentId);
    }
}
