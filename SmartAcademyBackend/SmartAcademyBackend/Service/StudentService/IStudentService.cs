using SmartAcademyBackend.DTOs.StudentDTOs;
using SmartAcademyBackend.Entities;

namespace SmartAcademyBackend.Service.StudentService
{
    public interface IStudentService
    {
        public Task<Student?> addNewStudent(AddStudentDTO newStudent);
    }
}
