using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicJournal.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Humans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Humans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    HumanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Humans_HumanId",
                        column: x => x.HumanId,
                        principalTable: "Humans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentClassId = table.Column<int>(type: "int", nullable: false),
                    HumanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Humans_HumanId",
                        column: x => x.HumanId,
                        principalTable: "Humans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassroomTeacherId = table.Column<int>(type: "int", nullable: false),
                    HeadmanId = table.Column<int>(type: "int", nullable: false),
                    HeadmanId1 = table.Column<int>(type: "int", nullable: true),
                    CurrentJournalId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Journals_CurrentJournalId",
                        column: x => x.CurrentJournalId,
                        principalTable: "Journals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Classes_Students_HeadmanId1",
                        column: x => x.HeadmanId1,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classes_Teachers_ClassroomTeacherId",
                        column: x => x.ClassroomTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubjectsInJournals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    JournalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsInJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectsInJournals_Journals_JournalId",
                        column: x => x.JournalId,
                        principalTable: "Journals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectsInJournals_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectsInJournals_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubjectInJournalId = table.Column<int>(type: "int", nullable: false),
                    HomeTask = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_SubjectsInJournals_SubjectInJournalId",
                        column: x => x.SubjectInJournalId,
                        principalTable: "SubjectsInJournals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonScores_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonScores_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassroomTeacherId",
                table: "Classes",
                column: "ClassroomTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CurrentJournalId",
                table: "Classes",
                column: "CurrentJournalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_HeadmanId1",
                table: "Classes",
                column: "HeadmanId1");

            migrationBuilder.CreateIndex(
                name: "IX_Humans_UserId",
                table: "Humans",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Journals_ClassId",
                table: "Journals",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SubjectInJournalId",
                table: "Lessons",
                column: "SubjectInJournalId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonScores_LessonId",
                table: "LessonScores",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonScores_StudentId",
                table: "LessonScores",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_HumanId",
                table: "Students",
                column: "HumanId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsInJournals_JournalId",
                table: "SubjectsInJournals",
                column: "JournalId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsInJournals_SubjectId",
                table: "SubjectsInJournals",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsInJournals_TeacherId",
                table: "SubjectsInJournals",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CurrentClassId",
                table: "Teachers",
                column: "CurrentClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_HumanId",
                table: "Teachers",
                column: "HumanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_Classes_ClassId",
                table: "Journals",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Classes_CurrentClassId",
                table: "Teachers",
                column: "CurrentClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Journals_CurrentJournalId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Students_HeadmanId1",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Teachers_ClassroomTeacherId",
                table: "Classes");

            migrationBuilder.DropTable(
                name: "LessonScores");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "SubjectsInJournals");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Journals");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Humans");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
