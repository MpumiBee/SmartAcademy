using Microsoft.EntityFrameworkCore;
using SmartAcademyBackend.Entities;

namespace SmartAcademyBackend.Data
{
    public class SmartAcademyDbContext(DbContextOptions<SmartAcademyDbContext> options) : DbContext(options)
    {
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<TimeSlots> TimeSlots { get; set; }
        public DbSet<TutorAvailability> TutorAvailabilities { get; set; }

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


            modelBuilder.Entity<Parent>()
           .HasMany(Parent => Parent.Students)
           .WithOne(student => student.Parent)
           .HasForeignKey(student => student.ParentId);

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
                .OnDelete(DeleteBehavior.NoAction); ;


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


        }
    }
}
