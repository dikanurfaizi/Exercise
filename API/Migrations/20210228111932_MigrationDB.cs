using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class MigrationDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_M_Person",
                columns: table => new
                {
                    Nik = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Person", x => x.Nik);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_University",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_University", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_Account",
                columns: table => new
                {
                    Nik = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Account", x => x.Nik);
                    table.ForeignKey(
                        name: "FK_Tb_M_Account_Tb_M_Person_Nik",
                        column: x => x.Nik,
                        principalTable: "Tb_M_Person",
                        principalColumn: "Nik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_Education",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_M_Education_Tb_M_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Tb_M_University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_Profiling",
                columns: table => new
                {
                    Nik = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EducationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Profiling", x => x.Nik);
                    table.ForeignKey(
                        name: "FK_Tb_M_Profiling_Tb_M_Account_Nik",
                        column: x => x.Nik,
                        principalTable: "Tb_M_Account",
                        principalColumn: "Nik",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_M_Profiling_Tb_M_Education_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Tb_M_Education",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_Education_UniversityId",
                table: "Tb_M_Education",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_Profiling_EducationId",
                table: "Tb_M_Profiling",
                column: "EducationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_M_Profiling");

            migrationBuilder.DropTable(
                name: "Tb_M_Account");

            migrationBuilder.DropTable(
                name: "Tb_M_Education");

            migrationBuilder.DropTable(
                name: "Tb_M_Person");

            migrationBuilder.DropTable(
                name: "Tb_M_University");
        }
    }
}
