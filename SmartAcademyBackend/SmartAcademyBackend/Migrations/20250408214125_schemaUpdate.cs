using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAcademyBackend.Migrations
{
    /// <inheritdoc />
    public partial class schemaUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_SubscriptionId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SubscriptionId",
                table: "Students",
                column: "SubscriptionId",
                unique: true,
                filter: "[SubscriptionId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_SubscriptionId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_SubscriptionId",
                table: "Students",
                column: "SubscriptionId",
                unique: true);
        }
    }
}
