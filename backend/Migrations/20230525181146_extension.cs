using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerdisc.Migrations
{
    /// <inheritdoc />
    public partial class extension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DissertationEntity_Projects_ProjectEntityId",
                table: "DissertationEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_DissertationEntity_Students_StudentId",
                table: "DissertationEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorProjectEntity_Professors_ProfessorId",
                table: "ProfessorProjectEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorProjectEntity_Projects_ProjectId",
                table: "ProfessorProjectEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseEntity_Courses_CourseId",
                table: "StudentCourseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseEntity_Students_StudentId",
                table: "StudentCourseEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourseEntity",
                table: "StudentCourseEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessorProjectEntity",
                table: "ProfessorProjectEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DissertationEntity",
                table: "DissertationEntity");

            migrationBuilder.RenameTable(
                name: "StudentCourseEntity",
                newName: "StudentCourses");

            migrationBuilder.RenameTable(
                name: "ProfessorProjectEntity",
                newName: "ProfessorProjects");

            migrationBuilder.RenameTable(
                name: "DissertationEntity",
                newName: "Dissertations");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourseEntity_StudentId",
                table: "StudentCourses",
                newName: "IX_StudentCourses_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourseEntity_CourseId",
                table: "StudentCourses",
                newName: "IX_StudentCourses_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorProjectEntity_ProjectId",
                table: "ProfessorProjects",
                newName: "IX_ProfessorProjects_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorProjectEntity_ProfessorId",
                table: "ProfessorProjects",
                newName: "IX_ProfessorProjects_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_DissertationEntity_StudentId",
                table: "Dissertations",
                newName: "IX_Dissertations_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_DissertationEntity_ProjectEntityId",
                table: "Dissertations",
                newName: "IX_Dissertations_ProjectEntityId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "Students",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProjectQualificationDate",
                table: "Students",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProjectDefenceDate",
                table: "Students",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "Students",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Students",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Students",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Projects",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Professors",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Courses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentCourses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProfessorProjects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Dissertations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessorProjects",
                table: "ProfessorProjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dissertations",
                table: "Dissertations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Extensions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    NumberOfDays = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Extensions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalResearcher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Institution = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalResearcher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalResearcher_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orientations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResearcherId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExternalResearcherId = table.Column<Guid>(type: "uuid", nullable: false),
                    DissertationId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orientations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orientations_Dissertations_DissertationId",
                        column: x => x.DissertationId,
                        principalTable: "Dissertations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orientations_ExternalResearcher_ExternalResearcherId",
                        column: x => x.ExternalResearcherId,
                        principalTable: "ExternalResearcher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orientations_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Extensions_StudentId",
                table: "Extensions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalResearcher_UserId",
                table: "ExternalResearcher",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orientations_DissertationId",
                table: "Orientations",
                column: "DissertationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orientations_ExternalResearcherId",
                table: "Orientations",
                column: "ExternalResearcherId");

            migrationBuilder.CreateIndex(
                name: "IX_Orientations_ProfessorId",
                table: "Orientations",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dissertations_Projects_ProjectEntityId",
                table: "Dissertations",
                column: "ProjectEntityId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dissertations_Students_StudentId",
                table: "Dissertations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorProjects_Professors_ProfessorId",
                table: "ProfessorProjects",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorProjects_Projects_ProjectId",
                table: "ProfessorProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Students_StudentId",
                table: "StudentCourses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dissertations_Projects_ProjectEntityId",
                table: "Dissertations");

            migrationBuilder.DropForeignKey(
                name: "FK_Dissertations_Students_StudentId",
                table: "Dissertations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorProjects_Professors_ProfessorId",
                table: "ProfessorProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorProjects_Projects_ProjectId",
                table: "ProfessorProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Students_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Extensions");

            migrationBuilder.DropTable(
                name: "Orientations");

            migrationBuilder.DropTable(
                name: "ExternalResearcher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessorProjects",
                table: "ProfessorProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dissertations",
                table: "Dissertations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProfessorProjects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Dissertations");

            migrationBuilder.RenameTable(
                name: "StudentCourses",
                newName: "StudentCourseEntity");

            migrationBuilder.RenameTable(
                name: "ProfessorProjects",
                newName: "ProfessorProjectEntity");

            migrationBuilder.RenameTable(
                name: "Dissertations",
                newName: "DissertationEntity");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourseEntity",
                newName: "IX_StudentCourseEntity_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourseEntity",
                newName: "IX_StudentCourseEntity_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorProjects_ProjectId",
                table: "ProfessorProjectEntity",
                newName: "IX_ProfessorProjectEntity_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorProjects_ProfessorId",
                table: "ProfessorProjectEntity",
                newName: "IX_ProfessorProjectEntity_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_Dissertations_StudentId",
                table: "DissertationEntity",
                newName: "IX_DissertationEntity_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Dissertations_ProjectEntityId",
                table: "DissertationEntity",
                newName: "IX_DissertationEntity_ProjectEntityId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "Students",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProjectQualificationDate",
                table: "Students",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProjectDefenceDate",
                table: "Students",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "Students",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Students",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Projects",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourseEntity",
                table: "StudentCourseEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessorProjectEntity",
                table: "ProfessorProjectEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DissertationEntity",
                table: "DissertationEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DissertationEntity_Projects_ProjectEntityId",
                table: "DissertationEntity",
                column: "ProjectEntityId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DissertationEntity_Students_StudentId",
                table: "DissertationEntity",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorProjectEntity_Professors_ProfessorId",
                table: "ProfessorProjectEntity",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorProjectEntity_Projects_ProjectId",
                table: "ProfessorProjectEntity",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseEntity_Courses_CourseId",
                table: "StudentCourseEntity",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseEntity_Students_StudentId",
                table: "StudentCourseEntity",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
