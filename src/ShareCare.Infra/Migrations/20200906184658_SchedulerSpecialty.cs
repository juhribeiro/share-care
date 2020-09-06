using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareCare.Infra.Migrations
{
    public partial class SchedulerSpecialty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedulers_Specialties_SpecialtyId",
                table: "Schedulers");

            migrationBuilder.DropIndex(
                name: "IX_Schedulers_SpecialtyId",
                table: "Schedulers");

            migrationBuilder.AddColumn<string>(
                name: "Specialty",
                table: "Schedulers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "Schedulers");

            migrationBuilder.CreateIndex(
                name: "IX_Schedulers_SpecialtyId",
                table: "Schedulers",
                column: "SpecialtyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulers_Specialties_SpecialtyId",
                table: "Schedulers",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id");
        }
    }
}
