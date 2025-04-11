using Microsoft.EntityFrameworkCore;
using SmartAcademyBackend.Data;
using SmartAcademyBackend.DTOs.BookingDTO;
using SmartAcademyBackend.Entities;

namespace SmartAcademyBackend.Service.BookingService
{
    public class BookingService(SmartAcademyDbContext _context) : IBookingService
    {
        private async Task<bool> isTutorExist(int tutorId)
        {
            return await _context.Tutors.AnyAsync(tutor=>tutor.TutorId==tutorId);
        }
        private async Task<bool> isStudentExist(int studentId)
        {
            return await _context.Students.AnyAsync(student => student.StudentId == studentId);
        }
        private async Task<bool> isSubjectExist(int subjectId)
        {
            return await _context.Subjects.AnyAsync(subject => subject.SubjectID == subjectId);
        }
        private async Task<bool> isSubjectTaughtByBookedTutor(int subjectId, int tutorId)
        {
            return await _context.Subjects
                .AnyAsync(s => s.SubjectID == subjectId &&
                               s.Tutors.Any(t => t.TutorId == tutorId));
        }


        private async Task<bool> isTutorAvailable(int tutorId,DateOnly dateOfSession,int tutorAvailableiD) { 
                var dayName = dateOfSession.DayOfWeek.ToString();
                var search = await _context.TutorAvailabilities
                                .Where(tutor=> tutor.TutorId== tutorId && 
                                               tutor.Day.ToString().ToLower().Equals(dayName.ToLower()) &&
                                               tutor.TutorAvailabilityId== tutorAvailableiD
                                               ).AnyAsync();

            return search;
        }
        


        private async Task<bool> isTeachingModeSame(int studentId,int tutorId)
        {
            var studentTeachingMode =await _context.Students
                                       .Where(student=> student.StudentId==studentId)
                                       .Select(student => student.TeachingMode)
                                       .FirstOrDefaultAsync();

            var tutorTeachingMode = await _context.Tutors
                                       .Where(tutor => tutor.TutorId == tutorId)
                                       .Select(tutor => tutor.TeachingMode)
                                       .FirstOrDefaultAsync();

            return studentTeachingMode.Equals(tutorTeachingMode);
        }
        public async Task<string> addNewBooking(AddbookingDTO addbookingDTO)
        {
            if (!await isStudentExist(addbookingDTO.StudentId))
                return "student does not exist";

            if (!await isTutorExist(addbookingDTO.TutorId))
                return "tutor does not exist";
         

            if (!await isTeachingModeSame(addbookingDTO.StudentId, addbookingDTO.TutorId))
                return "teaching mode not the same";

            if (!await isSubjectExist(addbookingDTO.SubjectId))
                return "subject doesnot exist";

            if (!await isSubjectTaughtByBookedTutor(addbookingDTO.SubjectId,addbookingDTO.TutorId))
                return "subject not taught by the tutor";

            if (!await isTutorAvailable(addbookingDTO.TutorId,addbookingDTO.sessionDate,addbookingDTO.tutorAvailabilityId))
                return "tutor not available on this day";

            Booking newBooking = new()
            {
                StudentId = addbookingDTO.StudentId,
                SubjectId = addbookingDTO.SubjectId,
                Date = addbookingDTO.sessionDate,
                TutorId = addbookingDTO.TutorId,
                AttendanceType = addbookingDTO.AttendanceType,
                TutorAvailabilityId = addbookingDTO.tutorAvailabilityId
            };

            _context.Add(newBooking);
            await _context.SaveChangesAsync();

            return "booking added";


        }
    }
}
