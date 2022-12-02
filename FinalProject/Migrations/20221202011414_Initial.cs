using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Names",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    birthdate = table.Column<DateTime>(nullable: false),
                    collegeProgram = table.Column<string>(nullable: true),
                    yearInProgram = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Names", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Names",
                columns: new[] { "Id", "birthdate", "collegeProgram", "name", "yearInProgram" },
                values: new object[] { 1, new DateTime(2000, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT - Game Design and Software Development", "Ben Devine", "Senior" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Names");
        }
    }
}
