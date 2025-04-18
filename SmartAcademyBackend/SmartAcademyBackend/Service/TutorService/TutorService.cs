using Microsoft.EntityFrameworkCore;
using SmartAcademyBackend.Data;
using SmartAcademyBackend.DTOs;
using SmartAcademyBackend.DTOs.TutorDTO;
using SmartAcademyBackend.Entities;


namespace SmartAcademyBackend.Service.TutorService
{
    public class TutorService(SmartAcademyDbContext _context) : ITutorService
    {
       
        //function for mapping subjects to a tutor
        private List<GetSubjectsDTO> mapSubjects(IEnumerable<Subjects> subjects)
        {
            return subjects.
                Select(subjects => new GetSubjectsDTO(
                    subjects.SubjectID, subjects.SubjectName))
                .ToList();
        }

        //function for mapping tutoravailabilityslots to a tutor
        private List<GetTutorAvailabilitySlots> mapTutorAvailability(IEnumerable<TutorAvailability> tutorAvailabilities)
        {
            return tutorAvailabilities.Select( TutorAvailability => new GetTutorAvailabilitySlots(
                                                TutorAvailability.Day.ToString(),
                                                TutorAvailability.TimeSlots!.EndTime,
                                                TutorAvailability.TimeSlots.StartTime
                                               )).ToList();
        }
        public async Task<Tutor?> addNewTutor(AddTutorDTO addTutor,int userId)
        {

            if (await _context.Tutors.AnyAsync(tutor => tutor.UserId == userId))
                return null;

            //check whethere the subject ids selected exist
            var selectedSubjectId = await _context.Subjects
                                    .Where(subject=> addTutor.SubjectID.Contains(subject.SubjectID))
                                    .ToListAsync();

           

            Tutor tutor = new()
            {
                ContactNumber = addTutor.ContactNumber,
                TeachingMode = addTutor.TeachingMode,
                TutorBio = addTutor.TutorBio,
                TutorName = addTutor.TutorName,
                TutorSurname = addTutor.TutorSurname,
                Subjects = selectedSubjectId,
                TutorAvailabilities = addTutor.TutorAvailability
                                       .Select(tutor => new TutorAvailability { 
                                           Day =tutor.Day,
                                           TimeSlotId = tutor.TimeSlotId,
                                       }).ToList()
            };

            
             _context.Tutors.Add(tutor);
            await _context.SaveChangesAsync();

            return tutor;
        }
       

        public async Task<GetTutorInfoDTO?> getTutorById(int tutotId)
        {
            
            var tutor = await _context.Tutors
                        .Include(tutor => tutor.Subjects)
                        .Include(tutor => tutor.TutorAvailabilities)
                                .ThenInclude(tutor => tutor.TimeSlots)
                        .Where(tutor => tutor.TutorId == tutotId)
                        .FirstOrDefaultAsync();

            if (tutor == null)
                return null;
            return new GetTutorInfoDTO(tutor.TutorId,
                                            tutor.TutorName,
                                            tutor.TutorSurname,
                                            tutor.ContactNumber,
                                            tutor.TutorBio,
                                            tutor.TeachingMode.ToString(),
                                            mapSubjects(tutor.Subjects),
                                            mapTutorAvailability(tutor.TutorAvailabilities)
                                            );
        }

        public async Task<List<GetTutorInfoDTO>?> getAllTutors()
        {

            var tutor = await _context.Tutors
                        .Include(tutor => tutor.Subjects)
                        .Include(tutor => tutor.TutorAvailabilities)
                                .ThenInclude(tutor => tutor.TimeSlots)
                       .Select(tutor=> new GetTutorInfoDTO(tutor.TutorId,
                                            tutor.TutorName,
                                            tutor.TutorSurname,
                                            tutor.ContactNumber,
                                            tutor.TutorBio,
                                            tutor.TeachingMode.ToString(),
                                            mapSubjects(tutor.Subjects),
                                            mapTutorAvailability(tutor.TutorAvailabilities)
                                            ))
                        .ToListAsync();


            return tutor;
        }
    }
}
