﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerdisc.Migrations
{
    /// <inheritdoc />
    public partial class newTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DissertationEntity_Projects_ProjectId",
                table: "DissertationEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Professors_Projects_ProjectEntityId",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseEntity_Courses_CourseId1",
                table: "StudentCourseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseEntity_Students_StudentId1",
                table: "StudentCourseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Projects_ProjectEntityId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ProjectEntityId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseEntity_CourseId1",
                table: "StudentCourseEntity");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseEntity_StudentId1",
                table: "StudentCourseEntity");

            migrationBuilder.DropIndex(
                name: "IX_Professors_ProjectEntityId",
                table: "Professors");

            migrationBuilder.DropIndex(
                name: "IX_DissertationEntity_ProjectId",
                table: "DissertationEntity");

            migrationBuilder.DropColumn(
                name: "ProjectEntityId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "StudentCourseEntity");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "StudentCourseEntity");

            migrationBuilder.DropColumn(
                name: "ProjectEntityId",
                table: "Professors");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "StudentCourseEntity",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "StudentCourseEntity",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<char>(
                name: "Grade",
                table: "StudentCourseEntity",
                type: "character(1)",
                nullable: false,
                defaultValue: ' ');

            migrationBuilder.AddColumn<int>(
                name: "Trimester",
                table: "StudentCourseEntity",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "StudentCourseEntity",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectEntityId",
                table: "DissertationEntity",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProfessorProjectEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorProjectEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessorProjectEntity_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorProjectEntity_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseEntity_CourseId",
                table: "StudentCourseEntity",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseEntity_StudentId",
                table: "StudentCourseEntity",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_DissertationEntity_ProjectEntityId",
                table: "DissertationEntity",
                column: "ProjectEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorProjectEntity_ProfessorId",
                table: "ProfessorProjectEntity",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorProjectEntity_ProjectId",
                table: "ProfessorProjectEntity",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_DissertationEntity_Projects_ProjectEntityId",
                table: "DissertationEntity",
                column: "ProjectEntityId",
                principalTable: "Projects",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DissertationEntity_Projects_ProjectEntityId",
                table: "DissertationEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseEntity_Courses_CourseId",
                table: "StudentCourseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseEntity_Students_StudentId",
                table: "StudentCourseEntity");

            migrationBuilder.DropTable(
                name: "ProfessorProjectEntity");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseEntity_CourseId",
                table: "StudentCourseEntity");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseEntity_StudentId",
                table: "StudentCourseEntity");

            migrationBuilder.DropIndex(
                name: "IX_DissertationEntity_ProjectEntityId",
                table: "DissertationEntity");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "StudentCourseEntity");

            migrationBuilder.DropColumn(
                name: "Trimester",
                table: "StudentCourseEntity");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "StudentCourseEntity");

            migrationBuilder.DropColumn(
                name: "ProjectEntityId",
                table: "DissertationEntity");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectEntityId",
                table: "Students",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentCourseEntity",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "StudentCourseEntity",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId1",
                table: "StudentCourseEntity",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId1",
                table: "StudentCourseEntity",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectEntityId",
                table: "Professors",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProjectEntityId",
                table: "Students",
                column: "ProjectEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseEntity_CourseId1",
                table: "StudentCourseEntity",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseEntity_StudentId1",
                table: "StudentCourseEntity",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Professors_ProjectEntityId",
                table: "Professors",
                column: "ProjectEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DissertationEntity_ProjectId",
                table: "DissertationEntity",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_DissertationEntity_Projects_ProjectId",
                table: "DissertationEntity",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_Projects_ProjectEntityId",
                table: "Professors",
                column: "ProjectEntityId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseEntity_Courses_CourseId1",
                table: "StudentCourseEntity",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseEntity_Students_StudentId1",
                table: "StudentCourseEntity",
                column: "StudentId1",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Projects_ProjectEntityId",
                table: "Students",
                column: "ProjectEntityId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
