using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartAcademyBackend.Migrations
{
    /// <inheritdoc />
    public partial class seedsubjectandtimeslots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "TimeSlots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectID", "SubjectName" },
                values: new object[,]
                {
                    { 1, "English" },
                    { 2, "Afrikaans" },
                    { 3, "IsiZulu" },
                    { 4, "Mathematics" },
                    { 5, "Life Skills" },
                    { 6, "Natural Sciences" },
                    { 7, "Social Sciences" },
                    { 8, "Life Orientation" },
                    { 9, "Economic Management Sciences" },
                    { 10, "Technology" },
                    { 11, "Creative Arts" },
                    { 12, "Mathematics Literacy" },
                    { 13, "Physical Sciences" },
                    { 14, "Accounting" },
                    { 15, "Business Studies" },
                    { 16, "Geography" },
                    { 17, "History" },
                    { 18, "Computer Applications Technology" },
                    { 19, "Information Technology" },
                    { 20, "Tourism" }
                });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "TimeSlotId", "DayOfWeek", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, 0, new TimeOnly(15, 0, 0), new TimeOnly(14, 0, 0) },
                    { 2, 0, new TimeOnly(16, 0, 0), new TimeOnly(15, 0, 0) },
                    { 3, 0, new TimeOnly(17, 0, 0), new TimeOnly(16, 0, 0) },
                    { 4, 1, new TimeOnly(15, 0, 0), new TimeOnly(14, 0, 0) },
                    { 5, 1, new TimeOnly(16, 0, 0), new TimeOnly(15, 0, 0) },
                    { 6, 1, new TimeOnly(17, 0, 0), new TimeOnly(16, 0, 0) },
                    { 7, 2, new TimeOnly(15, 0, 0), new TimeOnly(14, 0, 0) },
                    { 8, 2, new TimeOnly(16, 0, 0), new TimeOnly(15, 0, 0) },
                    { 9, 2, new TimeOnly(17, 0, 0), new TimeOnly(16, 0, 0) },
                    { 10, 3, new TimeOnly(15, 0, 0), new TimeOnly(14, 0, 0) },
                    { 11, 3, new TimeOnly(16, 0, 0), new TimeOnly(15, 0, 0) },
                    { 12, 3, new TimeOnly(17, 0, 0), new TimeOnly(16, 0, 0) },
                    { 13, 4, new TimeOnly(15, 0, 0), new TimeOnly(14, 0, 0) },
                    { 14, 4, new TimeOnly(16, 0, 0), new TimeOnly(15, 0, 0) },
                    { 15, 4, new TimeOnly(17, 0, 0), new TimeOnly(16, 0, 0) },
                    { 16, 5, new TimeOnly(11, 0, 0), new TimeOnly(10, 0, 0) },
                    { 18, 5, new TimeOnly(12, 0, 0), new TimeOnly(11, 0, 0) },
                    { 19, 5, new TimeOnly(13, 0, 0), new TimeOnly(12, 0, 0) },
                    { 20, 5, new TimeOnly(14, 0, 0), new TimeOnly(13, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotId",
                keyValue: 20);

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "TimeSlots");
        }
    }
}
