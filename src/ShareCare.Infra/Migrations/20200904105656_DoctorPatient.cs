using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareCare.Infra.Migrations
{
    public partial class DoctorPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorPatient",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DoctorId = table.Column<Guid>(nullable: false),
                    PatientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPatient", x => new { x.Id, x.DoctorId, x.PatientId });
                    table.ForeignKey(
                        name: "FK_DoctorPatient_Persons_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoctorPatient_Persons_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatient_DoctorId",
                table: "DoctorPatient",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatient_Id",
                table: "DoctorPatient",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatient_PatientId",
                table: "DoctorPatient",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorPatient");
        }
    }
}
