using SmartAcademyBackend.DTOs.StudentDTOs;
using SmartAcademyBackend.Entities;

namespace SmartAcademyBackend.Service.StudentService
{
    public interface IStudentService
    {
        public Task<Student?> addNewStudent(AddStudentDTO newStudent, int userId);
        public Task<List<GetStudentInfoDTO>> getAllStudentInformation();
        public Task<GetStudentInfoDTO?> getStudentInformationById(int studentId);
        public Task<string> editStudentInformation(int studentId,EditStudentDTO editStudent);
        public Task deactivateStudent(int studentId);
        public Task activateStudent(int studentId);
    }
}
