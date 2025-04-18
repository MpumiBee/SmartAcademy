﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartAcademyBackend.Data;

#nullable disable

namespace SmartAcademyBackend.Migrations
{
    [DbContext(typeof(SmartAcademyDbContext))]
    [Migration("20250418143202_userEntity")]
    partial class userEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmartAcademyBackend.Entities.Attendance", b =>
                {
                    b.Property<int>("AttendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttendanceId"));

                    b.Property<int>("AttendanceStatus")
                        .HasColumnType("int");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.HasKey("AttendanceId");

                    b.HasIndex("BookingId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<string>("AttendanceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookingStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TutorAvailabilityId")
                        .HasColumnType("int");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TutorAvailabilityId");

                    b.HasIndex("TutorId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.Parent", b =>
                {
                    b.Property<int>("ParentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParentId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParentId");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<bool>("IsStudentActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubscriptionId")
                        .HasColumnType("int");

                    b.Property<string>("TeachingMode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("ParentId");

                    b.HasIndex("SubscriptionId")
                        .IsUnique()
                        .HasFilter("[SubscriptionId] IS NOT NULL");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.Subjects", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectID"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectID");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            SubjectID = 1,
                            SubjectName = "English"
                        },
                        new
                        {
                            SubjectID = 2,
                            SubjectName = "Afrikaans"
                        },
                        new
                        {
                            SubjectID = 3,
                            SubjectName = "IsiZulu"
                        },
                        new
                        {
                            SubjectID = 4,
                            SubjectName = "Mathematics"
                        },
                        new
                        {
                            SubjectID = 5,
                            SubjectName = "Life Skills"
                        },
                        new
                        {
                            SubjectID = 6,
                            SubjectName = "Natural Sciences"
                        },
                        new
                        {
                            SubjectID = 7,
                            SubjectName = "Social Sciences"
                        },
                        new
                        {
                            SubjectID = 8,
                            SubjectName = "Life Orientation"
                        },
                        new
                        {
                            SubjectID = 9,
                            SubjectName = "Economic Management Sciences"
                        },
                        new
                        {
                            SubjectID = 10,
                            SubjectName = "Technology"
                        },
                        new
                        {
                            SubjectID = 11,
                            SubjectName = "Creative Arts"
                        },
                        new
                        {
                            SubjectID = 12,
                            SubjectName = "Mathematics Literacy"
                        },
                        new
                        {
                            SubjectID = 13,
                            SubjectName = "Physical Sciences"
                        },
                        new
                        {
                            SubjectID = 14,
                            SubjectName = "Accounting"
                        },
                        new
                        {
                            SubjectID = 15,
                            SubjectName = "Business Studies"
                        },
                        new
                        {
                            SubjectID = 16,
                            SubjectName = "Geography"
                        },
                        new
                        {
                            SubjectID = 17,
                            SubjectName = "History"
                        },
                        new
                        {
                            SubjectID = 18,
                            SubjectName = "Computer Applications Technology"
                        },
                        new
                        {
                            SubjectID = 19,
                            SubjectName = "Information Technology"
                        },
                        new
                        {
                            SubjectID = 20,
                            SubjectName = "Tourism"
                        });
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.SubscriptionPlans", b =>
                {
                    b.Property<int>("SubscriptionPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionPlanId"));

                    b.Property<int>("AttendanceType")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfLessons")
                        .HasColumnType("int");

                    b.Property<string>("SubscriptionPlanName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeachingMode")
                        .HasColumnType("int");

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("SubscriptionPlanId");

                    b.ToTable("SubscriptionPlans");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.TimeSlots", b =>
                {
                    b.Property<int>("TimeSlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeSlotId"));

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("TimeSlotId");

                    b.ToTable("TimeSlots");

                    b.HasData(
                        new
                        {
                            TimeSlotId = 1,
                            DayOfWeek = 0,
                            EndTime = new TimeOnly(15, 0, 0),
                            StartTime = new TimeOnly(14, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 2,
                            DayOfWeek = 0,
                            EndTime = new TimeOnly(16, 0, 0),
                            StartTime = new TimeOnly(15, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 3,
                            DayOfWeek = 0,
                            EndTime = new TimeOnly(17, 0, 0),
                            StartTime = new TimeOnly(16, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 4,
                            DayOfWeek = 1,
                            EndTime = new TimeOnly(15, 0, 0),
                            StartTime = new TimeOnly(14, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 5,
                            DayOfWeek = 1,
                            EndTime = new TimeOnly(16, 0, 0),
                            StartTime = new TimeOnly(15, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 6,
                            DayOfWeek = 1,
                            EndTime = new TimeOnly(17, 0, 0),
                            StartTime = new TimeOnly(16, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 7,
                            DayOfWeek = 2,
                            EndTime = new TimeOnly(15, 0, 0),
                            StartTime = new TimeOnly(14, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 8,
                            DayOfWeek = 2,
                            EndTime = new TimeOnly(16, 0, 0),
                            StartTime = new TimeOnly(15, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 9,
                            DayOfWeek = 2,
                            EndTime = new TimeOnly(17, 0, 0),
                            StartTime = new TimeOnly(16, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 10,
                            DayOfWeek = 3,
                            EndTime = new TimeOnly(15, 0, 0),
                            StartTime = new TimeOnly(14, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 11,
                            DayOfWeek = 3,
                            EndTime = new TimeOnly(16, 0, 0),
                            StartTime = new TimeOnly(15, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 12,
                            DayOfWeek = 3,
                            EndTime = new TimeOnly(17, 0, 0),
                            StartTime = new TimeOnly(16, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 13,
                            DayOfWeek = 4,
                            EndTime = new TimeOnly(15, 0, 0),
                            StartTime = new TimeOnly(14, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 14,
                            DayOfWeek = 4,
                            EndTime = new TimeOnly(16, 0, 0),
                            StartTime = new TimeOnly(15, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 15,
                            DayOfWeek = 4,
                            EndTime = new TimeOnly(17, 0, 0),
                            StartTime = new TimeOnly(16, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 16,
                            DayOfWeek = 5,
                            EndTime = new TimeOnly(11, 0, 0),
                            StartTime = new TimeOnly(10, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 18,
                            DayOfWeek = 5,
                            EndTime = new TimeOnly(12, 0, 0),
                            StartTime = new TimeOnly(11, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 19,
                            DayOfWeek = 5,
                            EndTime = new TimeOnly(13, 0, 0),
                            StartTime = new TimeOnly(12, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 20,
                            DayOfWeek = 5,
                            EndTime = new TimeOnly(14, 0, 0),
                            StartTime = new TimeOnly(13, 0, 0)
                        });
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.Tutor", b =>
                {
                    b.Property<int>("TutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TutorId"));

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeachingMode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TutorBio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TutorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TutorSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TutorId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Tutors");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.TutorAvailability", b =>
                {
                    b.Property<int>("TutorAvailabilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TutorAvailabilityId"));

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TimeSlotId")
                        .HasColumnType("int");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("TutorAvailabilityId");

                    b.HasIndex("TimeSlotId");

                    b.HasIndex("TutorId");

                    b.ToTable("TutorAvailabilities");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SubjectsStudents", b =>
                {
                    b.Property<int>("StudentsStudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectsSubjectID")
                        .HasColumnType("int");

                    b.HasKey("StudentsStudentId", "SubjectsSubjectID");

                    b.HasIndex("SubjectsSubjectID");

                    b.ToTable("SubjectsStudents");
                });

            modelBuilder.Entity("SubjectsTutors", b =>
                {
                    b.Property<int>("SubjectsSubjectID")
                        .HasColumnType("int");

                    b.Property<int>("TutorsTutorId")
                        .HasColumnType("int");

                    b.HasKey("SubjectsSubjectID", "TutorsTutorId");

                    b.HasIndex("TutorsTutorId");

                    b.ToTable("SubjectsTutors");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.Attendance", b =>
                {
                    b.HasOne("SmartAcademyBackend.Entities.Booking", "Booking")
                        .WithMany()
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.Booking", b =>
                {
                    b.HasOne("SmartAcademyBackend.Entities.Student", "Student")
                        .WithMany("Bookings")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartAcademyBackend.Entities.Subjects", "Subjects")
                        .WithMany("Bookings")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartAcademyBackend.Entities.TutorAvailability", "TutorAvailability")
                        .WithMany("Bookings")
                        .HasForeignKey("TutorAvailabilityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SmartAcademyBackend.Entities.Tutor", "Tutor")
                        .WithMany("Bookings")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subjects");

                    b.Navigation("Tutor");

                    b.Navigation("TutorAvailability");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.Payment", b =>
                {
                    b.HasOne("SmartAcademyBackend.Entities.Student", "Student")
                        .WithMany("Payments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartAcademyBackend.Entities.SubscriptionPlans", "SubscriptionPlans")
                        .WithMany("Payments")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("SubscriptionPlans");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.Student", b =>
                {
                    b.HasOne("SmartAcademyBackend.Entities.Parent", null)
                        .WithMany("Students")
                        .HasForeignKey("ParentId");

                    b.HasOne("SmartAcademyBackend.Entities.SubscriptionPlans", "SubscriptionPlans")
                        .WithOne("student")
                        .HasForeignKey("SmartAcademyBackend.Entities.Student", "SubscriptionId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmartAcademyBackend.Entities.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("SmartAcademyBackend.Entities.Student", "UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SubscriptionPlans");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.Tutor", b =>
                {
                    b.HasOne("SmartAcademyBackend.Entities.User", "User")
                        .WithOne("Tutor")
                        .HasForeignKey("SmartAcademyBackend.Entities.Tutor", "UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.TutorAvailability", b =>
                {
                    b.HasOne("SmartAcademyBackend.Entities.TimeSlots", "TimeSlots")
                        .WithMany("TutorAvailabilities")
                        .HasForeignKey("TimeSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartAcademyBackend.Entities.Tutor", "Tutor")
                        .WithMany("TutorAvailabilities")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TimeSlots");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("SubjectsStudents", b =>
                {
                    b.HasOne("SmartAcademyBackend.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartAcademyBackend.Entities.Subjects", null)
                        .WithMany()
                        .HasForeignKey("SubjectsSubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubjectsTutors", b =>
                {
                    b.HasOne("SmartAcademyBackend.Entities.Subjects", null)
                        .WithMany()
                        .HasForeignKey("SubjectsSubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartAcademyBackend.Entities.Tutor", null)
                        .WithMany()
                        .HasForeignKey("TutorsTutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.Parent", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.Student", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.Subjects", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.SubscriptionPlans", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("student");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.TimeSlots", b =>
                {
                    b.Navigation("TutorAvailabilities");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.Tutor", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("TutorAvailabilities");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.TutorAvailability", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("SmartAcademyBackend.Entities.User", b =>
                {
                    b.Navigation("Student");

                    b.Navigation("Tutor");
                });
#pragma warning restore 612, 618
        }
    }
}
