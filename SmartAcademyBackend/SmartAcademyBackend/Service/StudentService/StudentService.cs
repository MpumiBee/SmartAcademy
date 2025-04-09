using Microsoft.EntityFrameworkCore;
using SmartAcademyBackend.Data;
using SmartAcademyBackend.DTOs.ParentDTO;
using SmartAcademyBackend.DTOs.StudentDTOs;
using SmartAcademyBackend.DTOs.SubscriptionDTOs;
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

        public async Task<List<GetStudentInfoDTO>> getAllStudentInformation()
        {
            return await _context.Students
                                .Include(student => student.SubscriptionPlans)
                                .Include(student => student.Parent)
                                .Select(student => new GetStudentInfoDTO(
                                                     student.StudentId,
                                                     student.StudentName + " " + student.StudentSurname,
                                                     student.Email,
                                                     student.TeachingMode.ToString(),
                                                     student.Grade.ToString(),
                                                     student.Parent.ParentName+" "+student.Parent.ParentSurname,
                                                     student.Parent.Email,
                                                     /*
                                                      * check if the user has selected subscription plan
                                                      * if not return null
                                                      * else return the subscription mapped to  GetSubscriptionPlansDTO
                                                      */
                                                     student.SubscriptionPlans != null ? new GetSubscriptionPlansDTO(
                                                         student.SubscriptionPlans.SubscriptionPlanId,
                                                         student.SubscriptionPlans.NumberOfLessons,
                                                         student.SubscriptionPlans.AttendanceType.ToString(),
                                                         student.SubscriptionPlans.TeachingMode.ToString(),
                                                         student.SubscriptionPlans.amount
                                                         ):null


                                    ))
                               .ToListAsync();

        }

        public async Task<GetStudentInfoDTO?> getStudentInformationById(int studentId)
        {
            var student = await _context.Students
                                .Include(student => student.SubscriptionPlans)
                                .Include(student => student.Parent)
                                .Where(student => student.StudentId == studentId)
                                .Select(student => new GetStudentInfoDTO(
                                                     student.StudentId,
                                                     student.StudentName + " " + student.StudentSurname,
                                                     student.Email,
                                                     student.TeachingMode.ToString(),
                                                     student.Grade.ToString(),
                                                     student.Parent.ParentName + " " + student.Parent.ParentSurname,
                                                     student.Parent.Email,
                                                     student.SubscriptionPlans != null ? new GetSubscriptionPlansDTO(
                                                         student.SubscriptionPlans.SubscriptionPlanId,
                                                         student.SubscriptionPlans.NumberOfLessons,
                                                         student.SubscriptionPlans.AttendanceType.ToString(),
                                                         student.SubscriptionPlans.TeachingMode.ToString(),
                                                         student.SubscriptionPlans.amount
                                                         ) : null


                                    ))
                               .FirstOrDefaultAsync();

            if (student == null)
                return null;

            return student;

        }
    }
    

}
