using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAcademyBackend.Migrations
{
    /// <inheritdoc />
    public partial class userEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Parents_ParentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ParentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ParentId",
                table: "Users",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Parents_ParentId",
                table: "Users",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "ParentId");
        }
    }
}
