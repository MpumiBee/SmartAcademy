using Microsoft.EntityFrameworkCore;
using SmartAcademyBackend.Entities;
using SmartAcademyBackend.Enums;

namespace SmartAcademyBackend.Data
{
    public class SmartAcademyDbContext(DbContextOptions<SmartAcademyDbContext> options) : DbContext(options)
    {
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<TimeSlots> TimeSlots { get; set; }
        public DbSet<TutorAvailability> TutorAvailabilities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<SubscriptionPlans> SubscriptionPlans { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Subjects>()
               .HasMany(Subjects => Subjects.Bookings)
               .WithOne(booking => booking.Subjects)
               .HasForeignKey(Subjects => Subjects.SubjectId);

            modelBuilder.Entity<Subjects>()
            .HasMany(Subjects => Subjects.Tutors)
            .WithMany(Tutors => Tutors.Subjects)
            .UsingEntity("SubjectsTutors");

            modelBuilder.Entity<Tutor>()
            .HasMany(Tutor => Tutor.TutorAvailabilities)
            .WithOne(TutorAvailability => TutorAvailability.Tutor)
            .HasForeignKey(TutorAvailability => TutorAvailability.TutorId);

            modelBuilder.Entity<Tutor>()
                .Property(Tutor => Tutor.TeachingMode)
                .HasConversion<string>();

            modelBuilder.Entity<TutorAvailability>()
               .Property(TutorAvailability => TutorAvailability.Day)
               .HasConversion<string>();

            modelBuilder.Entity<Tutor>()
              .HasMany(Tutor => Tutor.Bookings)
              .WithOne(Booking => Booking.Tutor)
              .HasForeignKey(tutor => tutor.TutorId);

            modelBuilder.Entity<TimeSlots>()
           .HasMany(TimeSlots => TimeSlots.TutorAvailabilities)
           .WithOne(TutorAvailability => TutorAvailability.TimeSlots)
           .HasForeignKey(TutorAvailability => TutorAvailability.TimeSlotId);


           /* modelBuilder.Entity<Parent>()
           .HasMany(Parent => Parent.Students)
           .WithOne(student => student.Parent)
           .HasForeignKey(student => student.ParentId);*/

            modelBuilder.Entity<Subjects>()
            .HasMany(Subjects => Subjects.Students)
            .WithMany(Student => Student.Subjects)
            .UsingEntity("SubjectsStudents");

            modelBuilder.Entity<Student>()
               .Property(Student => Student.TeachingMode)
               .HasConversion<string>();

            modelBuilder.Entity<Student>()
                .HasMany(student => student.Payments)
                .WithOne(Payment => Payment.Student)
                .HasForeignKey(payment => payment.StudentId);

            modelBuilder.Entity<Student>()
                .HasOne(student => student.SubscriptionPlans)
                .WithOne(SubscriptionPlans => SubscriptionPlans.student)
                .HasForeignKey<Student>(student => student.SubscriptionId)
                .OnDelete(DeleteBehavior.NoAction); 


            modelBuilder.Entity<Student>()
                .HasMany(student => student.Bookings)
                .WithOne(booking => booking.Student)
                .HasForeignKey(student => student.StudentId);

            modelBuilder.Entity<Payment>()
               .HasOne(payment => payment.SubscriptionPlans)
               .WithMany(plan => plan.Payments)
               .HasForeignKey(plan => plan.SubscriptionId);

            modelBuilder.Entity<Payment>()
               .Property(payment => payment.PaymentStatus)
               .HasConversion<string>();

            modelBuilder.Entity<Booking>()
                .Property(booking => booking.AttendanceType)
                .HasConversion<string>();

            modelBuilder.Entity<Booking>()
               .Property(booking => booking.BookingStatus)
               .HasConversion<string>();

            modelBuilder.Entity<Booking>()
               .Property(booking => booking.AttendanceType)
               .HasConversion<string>();
            modelBuilder.Entity<TutorAvailability>()
    .HasMany(t => t.Bookings)
    .WithOne(b => b.TutorAvailability)
    .HasForeignKey(b => b.TutorAvailabilityId)
    .OnDelete(DeleteBehavior.NoAction);




            //seeding data to my db
            modelBuilder.Entity<Subjects>().HasData(
            new Subjects { SubjectID = 1, SubjectName = "English" },
             new Subjects { SubjectID = 2, SubjectName = "Afrikaans" },
             new Subjects { SubjectID = 3, SubjectName = "IsiZulu" },
            new Subjects { SubjectID = 4, SubjectName = "Mathematics" },
            new Subjects { SubjectID = 5, SubjectName = "Life Skills" },
            new Subjects { SubjectID = 6, SubjectName = "Natural Sciences" },
            new Subjects { SubjectID = 7, SubjectName = "Social Sciences" },
            new Subjects { SubjectID = 8, SubjectName = "Life Orientation" },
            new Subjects { SubjectID = 9, SubjectName = "Economic Management Sciences" },
            new Subjects { SubjectID = 10, SubjectName = "Technology" },
            new Subjects { SubjectID = 11, SubjectName = "Creative Arts" },
            new Subjects { SubjectID = 12, SubjectName = "Mathematics Literacy" },
            new Subjects { SubjectID = 13, SubjectName = "Physical Sciences" },
            new Subjects { SubjectID = 14, SubjectName = "Accounting" },
            new Subjects { SubjectID = 15, SubjectName = "Business Studies" },
            new Subjects { SubjectID = 16, SubjectName = "Geography" },
            new Subjects { SubjectID = 17, SubjectName = "History" },
            new Subjects { SubjectID = 18, SubjectName = "Computer Applications Technology" },
            new Subjects { SubjectID = 19, SubjectName = "Information Technology" },
            new Subjects { SubjectID = 20, SubjectName = "Tourism" }
            );


            modelBuilder.Entity<TimeSlots>().HasData(
             // Monday
             new TimeSlots { TimeSlotId = 1, DayOfWeek = DaysOfTheWeek.Monday, StartTime = new TimeOnly(14, 0), EndTime = new TimeOnly(15, 0) },
             new TimeSlots { TimeSlotId = 2, DayOfWeek = DaysOfTheWeek.Monday, StartTime = new TimeOnly(15, 0), EndTime = new TimeOnly(16, 0) },
             new TimeSlots { TimeSlotId = 3, DayOfWeek = DaysOfTheWeek.Monday, StartTime = new TimeOnly(16, 0), EndTime = new TimeOnly(17, 0) },

             // Tuesday
             new TimeSlots { TimeSlotId = 4, DayOfWeek = DaysOfTheWeek.Tuesday, StartTime = new TimeOnly(14, 0), EndTime = new TimeOnly(15, 0) },
             new TimeSlots { TimeSlotId = 5, DayOfWeek = DaysOfTheWeek.Tuesday, StartTime = new TimeOnly(15, 0), EndTime = new TimeOnly(16, 0) },
             new TimeSlots { TimeSlotId = 6, DayOfWeek = DaysOfTheWeek.Tuesday, StartTime = new TimeOnly(16, 0), EndTime = new TimeOnly(17, 0) },

             // Wednesday
             new TimeSlots { TimeSlotId = 7, DayOfWeek = DaysOfTheWeek.Wednesday, StartTime = new TimeOnly(14, 0), EndTime = new TimeOnly(15, 0) },
             new TimeSlots { TimeSlotId = 8, DayOfWeek = DaysOfTheWeek.Wednesday, StartTime = new TimeOnly(15, 0), EndTime = new TimeOnly(16, 0) },
             new TimeSlots { TimeSlotId = 9, DayOfWeek = DaysOfTheWeek.Wednesday, StartTime = new TimeOnly(16, 0), EndTime = new TimeOnly(17, 0) },

             // Thursday
             new TimeSlots { TimeSlotId = 10, DayOfWeek = DaysOfTheWeek.Thursday, StartTime = new TimeOnly(14, 0), EndTime = new TimeOnly(15, 0) },
             new TimeSlots { TimeSlotId = 11, DayOfWeek = DaysOfTheWeek.Thursday, StartTime = new TimeOnly(15, 0), EndTime = new TimeOnly(16, 0) },
             new TimeSlots { TimeSlotId = 12, DayOfWeek = DaysOfTheWeek.Thursday, StartTime = new TimeOnly(16, 0), EndTime = new TimeOnly(17, 0) },

             // Friday
             new TimeSlots { TimeSlotId = 13, DayOfWeek = DaysOfTheWeek.Friday, StartTime = new TimeOnly(14, 0), EndTime = new TimeOnly(15, 0) },
             new TimeSlots { TimeSlotId = 14, DayOfWeek = DaysOfTheWeek.Friday, StartTime = new TimeOnly(15, 0), EndTime = new TimeOnly(16, 0) },
             new TimeSlots { TimeSlotId = 15, DayOfWeek = DaysOfTheWeek.Friday, StartTime = new TimeOnly(16, 0), EndTime = new TimeOnly(17, 0) },

             // Saturday
             new TimeSlots { TimeSlotId = 16, DayOfWeek = DaysOfTheWeek.Saturday, StartTime = new TimeOnly(10, 0), EndTime = new TimeOnly(11, 0) },
             new TimeSlots { TimeSlotId = 18, DayOfWeek = DaysOfTheWeek.Saturday, StartTime = new TimeOnly(11, 0), EndTime = new TimeOnly(12, 0) },
             new TimeSlots { TimeSlotId = 19, DayOfWeek = DaysOfTheWeek.Saturday, StartTime = new TimeOnly(12, 0), EndTime = new TimeOnly(13, 0) },
             new TimeSlots { TimeSlotId = 20, DayOfWeek = DaysOfTheWeek.Saturday, StartTime = new TimeOnly(13, 0), EndTime = new TimeOnly(14, 0) }
         );

            modelBuilder.Entity<Tutor>()
           .HasOne(u => u.User)
           .WithOne(t => t.Tutor)
           .HasForeignKey<Tutor>(t => t.UserId)
           .OnDelete(DeleteBehavior.NoAction); ;

            modelBuilder.Entity<Student>()
            .HasOne(u => u.User)
            .WithOne(t => t.Student)
            .HasForeignKey<Student>(t => t.UserId)
            .OnDelete(DeleteBehavior.NoAction); ;





        }
    }
}
