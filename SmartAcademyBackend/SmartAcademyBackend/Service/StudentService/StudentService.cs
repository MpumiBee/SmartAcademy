using Microsoft.EntityFrameworkCore;
using SmartAcademyBackend.Data;
using SmartAcademyBackend.DTOs.StudentDTOs;
using SmartAcademyBackend.DTOs.SubscriptionDTOs;
using SmartAcademyBackend.Entities;

namespace SmartAcademyBackend.Service.StudentService
{
    public class StudentService(SmartAcademyDbContext _context):IStudentService
    {
       
        private async Task<bool> isStudentExists(int userId)
        {
            return await _context.Students
                        .AnyAsync(Student => Student.UserId == userId);


        }


        public async Task<Student?> addNewStudent(AddStudentDTO newStudent, int userId)
        {

            if (await isStudentExists(userId))
                return null;

            // var parentId = await searchParentId(newStudent.Parent.Email);

            /* Student student;


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

             }*/

            Student student = new()
            {
             
                Grade = newStudent.Grade,
                StudentName = newStudent.StudentName,
                StudentSurname = newStudent.StudentSurname,
                TeachingMode = newStudent.TeachingMode,
                SubscriptionId = newStudent.SubscriptionId,
                UserId = userId
                

            };


            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<List<GetStudentInfoDTO>> getAllStudentInformation()
        {
            return await _context.Students
                                .Include(student => student.SubscriptionPlans)
                                .Include(student => student.SubscriptionPlans)
                                .Select(student => new GetStudentInfoDTO(
                                                     student.StudentId,
                                                     student.StudentName + " " + student.StudentSurname,
                                                     student.TeachingMode.ToString(),
                                                     student.Grade.ToString(),
                                                     
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
                                                         ):null,
                                                     student.IsStudentActive


                                    ))
                               .ToListAsync();

        }

        public async Task<GetStudentInfoDTO?> getStudentInformationById(int studentId)
        {
            var student = await _context.Students
                                .Include(student => student.SubscriptionPlans)
                                .Where(student => student.StudentId == studentId)
                                .Select(student => new GetStudentInfoDTO(
                                                     student.StudentId,
                                                     student.StudentName + " " + student.StudentSurname,
                                                     student.TeachingMode.ToString(),
                                                     student.Grade.ToString(),
                                                     student.SubscriptionPlans != null ? new GetSubscriptionPlansDTO(
                                                         student.SubscriptionPlans.SubscriptionPlanId,
                                                         student.SubscriptionPlans.NumberOfLessons,
                                                         student.SubscriptionPlans.AttendanceType.ToString(),
                                                         student.SubscriptionPlans.TeachingMode.ToString(),
                                                         student.SubscriptionPlans.amount
                                                         ) : null,
                                                     student.IsStudentActive



                                    ))
                               .FirstOrDefaultAsync();

            if (student == null)
                return null;

            return student;

        }

        public async Task<string> editStudentInformation(int studentId, EditStudentDTO editStudent)
        {
            var student =await  _context.Students.FindAsync( studentId );

            if (student is null)
                return "student not found";

            student.StudentName = editStudent.StudentName;
            student.StudentSurname = editStudent.StudentSurname;
            student.Grade = editStudent.Grade;
            student.SubscriptionId = editStudent.subscriptionId;
         

            await _context.SaveChangesAsync();
            return "updated";
        }

        public async Task deactivateStudent(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId );
            if (student is null)
                return;
            student.IsStudentActive=false;
            await _context.SaveChangesAsync();
        }

        public async Task activateStudent(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student is null)
                return;
            student.IsStudentActive = true;
            await _context.SaveChangesAsync();
        }
    }
    

}
