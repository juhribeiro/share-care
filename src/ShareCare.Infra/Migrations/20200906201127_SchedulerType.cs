using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareCare.Infra.Migrations
{
    public partial class SchedulerType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Schedulers");

            migrationBuilder.AddColumn<string>(
                name: "MeetAddressLink",
                table: "Schedulers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Schedulers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetAddressLink",
                table: "Schedulers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Schedulers");

            migrationBuilder.AddColumn<Guid>(
                name: "SpecialtyId",
                table: "Schedulers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
