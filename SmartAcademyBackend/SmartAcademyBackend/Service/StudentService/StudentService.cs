using Microsoft.EntityFrameworkCore;
using SmartAcademyBackend.Data;
using SmartAcademyBackend.DTOs.ParentDTO;
using SmartAcademyBackend.DTOs.StudentDTOs;
using SmartAcademyBackend.Entities;

namespace SmartAcademyBackend.Service.StudentService
{
    public class StudentService(SmartAcademyDbContext _context):IStudentService
    {
        private async Task<int> searchParentId(string email)
        {
            return await _context.Parents
                        .Where(parent => parent.Email.ToLower().Equals(email.ToLower()))
                        .Select(parent => parent.ParentId)
                        .FirstOrDefaultAsync();
            

        }
        private async Task<bool> isStudentEmailExists(string email)
        {
            return await _context.Students
                        .Where(Student => Student.Email.ToLower().Equals(email.ToLower()))
                        .AnyAsync();


        }

       
        public async Task<Student?> addNewStudent(AddStudentDTO newStudent)
        {
            
            if (await isStudentEmailExists(newStudent.Email))
                return null;

            var parentId = await searchParentId(newStudent.Parent.Email);
           
            Student student;


            if (parentId==0)
            {
               
                Parent parent = new()
                {
                    ParentSurname = newStudent.Parent.ParentSurname,
                    Email= newStudent.Parent.Email,
                    ParentName = newStudent.Parent.ParentName, 
                };

                 _context.Parents.Add(parent);
                await _context.SaveChangesAsync();

                parentId = await searchParentId(parent.Email);

            }
            
            student = new()
            {
                Email = newStudent.Email,
                Grade = newStudent.Grade,
                StudentName = newStudent.StudentName,
                StudentSurname = newStudent.StudentSurname,
                TeachingMode = newStudent.TeachingMode,
                ParentId = parentId,
                SubscriptionId = newStudent.SubscriptionId

            };


            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        
    }
}
