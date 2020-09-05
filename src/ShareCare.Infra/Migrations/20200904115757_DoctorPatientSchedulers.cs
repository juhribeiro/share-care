using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ShareCare.Infra.Migrations
{
    public partial class DoctorPatientSchedulers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorPatient",
                table: "DoctorPatient");

            migrationBuilder.DropIndex(
                name: "IX_DoctorPatient_Id",
                table: "DoctorPatient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorPatient",
                table: "DoctorPatient",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Schedulers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateStart = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false),
                    SpecialtyId = table.Column<Guid>(nullable: false),
                    DoctorPatientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedulers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedulers_DoctorPatient_DoctorPatientId",
                        column: x => x.DoctorPatientId,
                        principalTable: "DoctorPatient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedulers_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedulers_DoctorPatientId",
                table: "Schedulers",
                column: "DoctorPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedulers_SpecialtyId",
                table: "Schedulers",
                column: "SpecialtyId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedulers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorPatient",
                table: "DoctorPatient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorPatient",
                table: "DoctorPatient",
                columns: new[] { "Id", "DoctorId", "PatientId" });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatient_Id",
                table: "DoctorPatient",
                column: "Id",
                unique: true);
        }
    }
}
