using Microsoft.EntityFrameworkCore;
using SmartAcademyBackend.Data;
using SmartAcademyBackend.DTOs.BookingDTO;
using SmartAcademyBackend.Entities;
using SmartAcademyBackend.Enums;

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

        private async Task<bool> isTutorBooked(int tutorId,DateOnly bookingDate,int tutorAvailabilityId)
        {
            return await _context.Bookings.AnyAsync(booking=> booking.TutorId==tutorId && 
                                                               booking.TutorAvailabilityId==tutorAvailabilityId &&
                                                               booking.Date.Equals(bookingDate)
                
                );
        }

        private async Task<AttendanceType?> getAttendance(int tutorId, DateOnly bookingDate, int tutorAvailabilityId)
        {
            if (await isTutorBooked(tutorId, bookingDate, tutorAvailabilityId))
            {
                return await _context.Bookings
                             .Where(booking => booking.TutorId == tutorId &&
                                               booking.TutorAvailabilityId == tutorAvailabilityId &&
                                               booking.Date.Equals(bookingDate))
                              .Select(booking => booking.AttendanceType)
                              .FirstOrDefaultAsync();
                             
                              
            }
            return null;
        }
        private async Task<bool> hasStudentBooked(int studentId, DateOnly bookingDate, int tutorAvailabilityId)
        {
          
                return await _context.Bookings
                             .Where(booking => booking.StudentId == studentId &&
                                               booking.TutorAvailabilityId == tutorAvailabilityId &&
                                               booking.Date.Equals(bookingDate))
                              .AnyAsync();

        
        }
        public async Task<string> addNewBooking(AddbookingDTO addbookingDTO)
        {
            var getAttendanceType = await getAttendance(addbookingDTO.TutorId,addbookingDTO.sessionDate,addbookingDTO.tutorAvailabilityId);

            if (await hasStudentBooked(addbookingDTO.StudentId, addbookingDTO.sessionDate, addbookingDTO.tutorAvailabilityId))
                return "student has already booked";

            if (getAttendanceType == AttendanceType.OneOnOne)
                return "One on One session booked";


            if (getAttendanceType == AttendanceType.Group && addbookingDTO.AttendanceType == AttendanceType.OneOnOne)
                return "Group session booked";

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

        public async Task<List<GetBookingDTO>> getAllBookings()
        {
            return await _context.Bookings
                   .Include(booking=>booking.Student)
                   .Include(booking=>booking.Tutor) 
                   .Include(booking=>booking.Subjects)
                   .Include(booking=>booking.TutorAvailability)
                   .Select(booking=>new GetBookingDTO(
                                    booking.BookingId,
                                    booking.Student.StudentName +" "+booking.Student.StudentSurname,
                                    booking.Student.Email,
                                    booking.Tutor.TutorName+" "+ booking.Tutor.TutorName,
                                    booking.Tutor.Email,
                                    booking.Subjects.SubjectName,
                                    booking.Date,
                                    booking.TutorAvailability.TimeSlots.StartTime,
                                    booking.TutorAvailability.TimeSlots.EndTime,
                                    booking.Date.DayOfWeek.ToString(),
                                    booking.AttendanceType.ToString(),
                                    booking.Tutor.TeachingMode.ToString(),
                                    booking.BookingStatus.ToString()


                       )).ToListAsync();
        }

        public async Task<List<GetBookingDTO>> getBookingByStudentId(int studentId)
        {
            return await _context.Bookings
                    .Include(booking => booking.Student)
                    .Include(booking => booking.Tutor)
                    .Include(booking => booking.Subjects)
                    .Include(booking => booking.TutorAvailability)
                    .Where(booking=>booking.StudentId==studentId)
                    .Select(booking => new GetBookingDTO(
                                     booking.BookingId,
                                     booking.Student.StudentName + " " + booking.Student.StudentSurname,
                                     booking.Student.Email,
                                     booking.Tutor.TutorName + " " + booking.Tutor.TutorName,
                                     booking.Tutor.Email,
                                     booking.Subjects.SubjectName,
                                     booking.Date,
                                     booking.TutorAvailability.TimeSlots.StartTime,
                                     booking.TutorAvailability.TimeSlots.EndTime,
                                     booking.Date.DayOfWeek.ToString(),
                                     booking.AttendanceType.ToString(),
                                     booking.Tutor.TeachingMode.ToString(),
                                     booking.BookingStatus.ToString()


                        )).ToListAsync();
        }

        public async Task<List<GetBookingDTO>> getBookingByTutorId(int tutorId)
        {
            return await _context.Bookings
                  .Include(booking => booking.Student)
                  .Include(booking => booking.Tutor)
                  .Include(booking => booking.Subjects)
                  .Include(booking => booking.TutorAvailability)
                  .Where(booking => booking.TutorId == tutorId)
                  .Select(booking => new GetBookingDTO(
                                   booking.BookingId,
                                   booking.Student.StudentName + " " + booking.Student.StudentSurname,
                                   booking.Student.Email,
                                   booking.Tutor.TutorName + " " + booking.Tutor.TutorName,
                                   booking.Tutor.Email,
                                   booking.Subjects.SubjectName,
                                   booking.Date,
                                   booking.TutorAvailability.TimeSlots.StartTime,
                                   booking.TutorAvailability.TimeSlots.EndTime,
                                   booking.Date.DayOfWeek.ToString(),
                                   booking.AttendanceType.ToString(),
                                   booking.Tutor.TeachingMode.ToString(),
                                   booking.BookingStatus.ToString()


                      )).ToListAsync();
        }

        public async Task deleteBooking(int bookingId)
        {
           var booking =await  _context.Bookings
                         .Where(booking=>booking.BookingId==bookingId)
                         .FirstOrDefaultAsync();

            if (booking == null)
                return;

            booking.BookingStatus = BookingStatus.Cancelled;
            await _context.SaveChangesAsync();

        }

        public async Task<List<GetBookingDTO>> getBookingsByDate(DateOnly bookingsDate)
        {
            return await _context.Bookings
                   .Where(booking=>booking.Date.Equals(bookingsDate))
                   .Select(booking => new GetBookingDTO(
                                   booking.BookingId,
                                   booking.Student.StudentName + " " + booking.Student.StudentSurname,
                                   booking.Student.Email,
                                   booking.Tutor.TutorName + " " + booking.Tutor.TutorName,
                                   booking.Tutor.Email,
                                   booking.Subjects.SubjectName,
                                   booking.Date,
                                   booking.TutorAvailability.TimeSlots.StartTime,
                                   booking.TutorAvailability.TimeSlots.EndTime,
                                   booking.Date.DayOfWeek.ToString(),
                                   booking.AttendanceType.ToString(),
                                   booking.Tutor.TeachingMode.ToString(),
                                   booking.BookingStatus.ToString()
                                   ))
                   .ToListAsync();
        }

        public async Task<GetBookingDTO?> getBookingsByBookingId(int bookingId)
        {
            return await _context.Bookings
                   .Where(booking => booking.BookingId==bookingId)
                   .Select(booking => new GetBookingDTO(
                                   booking.BookingId,
                                   booking.Student.StudentName + " " + booking.Student.StudentSurname,
                                   booking.Student.Email,
                                   booking.Tutor.TutorName + " " + booking.Tutor.TutorName,
                                   booking.Tutor.Email,
                                   booking.Subjects.SubjectName,
                                   booking.Date,
                                   booking.TutorAvailability.TimeSlots.StartTime,
                                   booking.TutorAvailability.TimeSlots.EndTime,
                                   booking.Date.DayOfWeek.ToString(),
                                   booking.AttendanceType.ToString(),
                                   booking.Tutor.TeachingMode.ToString(),
                                   booking.BookingStatus.ToString()
                                   ))
                   .FirstOrDefaultAsync();
        }
    }
}
