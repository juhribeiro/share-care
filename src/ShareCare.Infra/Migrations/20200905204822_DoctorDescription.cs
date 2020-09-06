using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareCare.Infra.Migrations
{
    public partial class DoctorDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Persons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Persons");
        }
    }
}
