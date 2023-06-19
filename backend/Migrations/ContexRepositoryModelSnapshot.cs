﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using gerdisc.Infrastructure.Repositories;

#nullable disable

namespace gerdisc.Migrations
{
    [DbContext(typeof(ContexRepository))]
    partial class ContexRepositoryModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("gerdisc.Models.Entities.CourseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Concept")
                        .HasColumnType("text");

                    b.Property<int>("Credits")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsElective")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Courses", (string)null);
                });

            modelBuilder.Entity("gerdisc.Models.Entities.DissertationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("ProjectEntityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("StudentEntityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProjectEntityId");

                    b.HasIndex("StudentEntityId");

                    b.HasIndex("StudentId");

                    b.ToTable("Dissertations");
                });

            modelBuilder.Entity("gerdisc.Models.Entities.ExtensionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("NumberOfDays")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Extensions");
                });

            modelBuilder.Entity("gerdisc.Models.Entities.ExternalResearcherEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Institution")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ExternalResearchers");
                });

            modelBuilder.Entity("gerdisc.Models.Entities.OrientationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CoorientatorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DissertationId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ProfessorId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CoorientatorId");

                    b.HasIndex("DissertationId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Orientations");
                });

            modelBuilder.Entity("gerdisc.Models.Entities.ProfessorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Siape")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Professors", (string)null);
                });

            modelBuilder.Entity("gerdisc.Models.Entities.ProfessorProjectEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ProfessorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProfessorProjects");
                });

            modelBuilder.Entity("gerdisc.Models.Entities.ProjectEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Projects", (string)null);
                });

            modelBuilder.Entity("gerdisc.Models.Entities.StudentCourseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uuid");

                    b.Property<char>("Grade")
                        .HasColumnType("character(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<int>("Trimester")
                        .HasColumnType("integer");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("gerdisc.Models.Entities.StudentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CPF")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("EntryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GraduationYear")
                        .HasColumnType("integer");

                    b.Property<int>("InstitutionType")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastNotification")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Proficiency")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ProjectDefenceDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ProjectId")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ProjectQualificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Registration")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Scholarship")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("UndergraduateArea")
                        .HasColumnType("integer");

                    b.Property<string>("UndergraduateCourse")
                        .HasColumnType("text");

                    b.Property<string>("UndergraduateInstitution")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("gerdisc.Models.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cpf")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("gerdisc.Models.Entities.DissertationEntity", b =>
                {
                    b.HasOne("gerdisc.Models.Entities.ProjectEntity", null)
                        .WithMany("Dissertations")
                        .HasForeignKey("ProjectEntityId");

                    b.HasOne("gerdisc.Models.Entities.StudentEntity", null)
                        .WithMany("Dissertations")
                        .HasForeignKey("StudentEntityId");

                    b.HasOne("gerdisc.Models.Entities.UserEntity", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("gerdisc.Models.Entities.ExtensionEntity", b =>
                {
                    b.HasOne("gerdisc.Models.Entities.UserEntity", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("gerdisc.Models.Entities.ExternalResearcherEntity", b =>
                {
                    b.HasOne("gerdisc.Models.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("gerdisc.Models.Entities.OrientationEntity", b =>
                {
                    b.HasOne("gerdisc.Models.Entities.UserEntity", "Coorientator")
                        .WithMany()
                        .HasForeignKey("CoorientatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gerdisc.Models.Entities.DissertationEntity", "Dissertation")
                        .WithMany()
                        .HasForeignKey("DissertationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gerdisc.Models.Entities.UserEntity", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coorientator");

                    b.Navigation("Dissertation");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("gerdisc.Models.Entities.ProfessorEntity", b =>
                {
                    b.HasOne("gerdisc.Models.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("gerdisc.Models.Entities.ProfessorProjectEntity", b =>
                {
                    b.HasOne("gerdisc.Models.Entities.UserEntity", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gerdisc.Models.Entities.ProjectEntity", "Project")
                        .WithMany("ProfessorProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("gerdisc.Models.Entities.StudentCourseEntity", b =>
                {
                    b.HasOne("gerdisc.Models.Entities.CourseEntity", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gerdisc.Models.Entities.StudentEntity", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("gerdisc.Models.Entities.StudentEntity", b =>
                {
                    b.HasOne("gerdisc.Models.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("gerdisc.Models.Entities.UserEntity", b =>
                {
                    b.HasOne("gerdisc.Models.Entities.ProjectEntity", null)
                        .WithMany("Students")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("gerdisc.Models.Entities.ProjectEntity", b =>
                {
                    b.Navigation("Dissertations");

                    b.Navigation("ProfessorProjects");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("gerdisc.Models.Entities.StudentEntity", b =>
                {
                    b.Navigation("Dissertations");

                    b.Navigation("StudentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
