using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAcademyBackend.Migrations
{
    /// <inheritdoc />
    public partial class updateBookingSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_TimeSlots_TimeSlotsTimeSlotId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "TimeSlotId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "TimeSlotsTimeSlotId",
                table: "Bookings",
                newName: "TutorAvailabilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_TimeSlotsTimeSlotId",
                table: "Bookings",
                newName: "IX_Bookings_TutorAvailabilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_TutorAvailabilities_TutorAvailabilityId",
                table: "Bookings",
                column: "TutorAvailabilityId",
                principalTable: "TutorAvailabilities",
                principalColumn: "TutorAvailabilityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_TutorAvailabilities_TutorAvailabilityId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "TutorAvailabilityId",
                table: "Bookings",
                newName: "TimeSlotsTimeSlotId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_TutorAvailabilityId",
                table: "Bookings",
                newName: "IX_Bookings_TimeSlotsTimeSlotId");

            migrationBuilder.AddColumn<int>(
                name: "TimeSlotId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_TimeSlots_TimeSlotsTimeSlotId",
                table: "Bookings",
                column: "TimeSlotsTimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "TimeSlotId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
