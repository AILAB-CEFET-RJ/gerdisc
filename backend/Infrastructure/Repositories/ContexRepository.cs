using gerdisc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace gerdisc.Infrastructure.Repositories
{
    public class ContexRepository : DbContext
    {
        public string? DbUrl { get; }

        public DbSet<UserEntity>? Users { get; set; }
        public DbSet<StudentEntity>? Students { get; set; }
        public DbSet<ProfessorEntity>? Professors { get; set; }
        public DbSet<CourseEntity>? Courses { get; set; }
        public DbSet<ProjectEntity>? Projects { get; set; }
        public DbSet<ExternalResearcherEntity>? ExternalResearcher { get; set; }
        public DbSet<DissertationEntity>? Dissertations { get; set; } 
        public DbSet<ExtensionEntity>? Extensions { get; set; } 
        public DbSet<ProfessorProjectEntity>? ProfessorProjects { get; set; } 
        public DbSet<StudentCourseEntity>? StudentCourses { get; set; } 
        public DbSet<OrientationEntity>? Orientations { get; set; } 

        public ContexRepository(DbContextOptions<ContexRepository> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("Users");
            modelBuilder.Entity<StudentEntity>().ToTable("Students");
            modelBuilder.Entity<ProfessorEntity>().ToTable("Professors");
            modelBuilder.Entity<CourseEntity>().ToTable("Courses");
            modelBuilder.Entity<ProjectEntity>().ToTable("Projects");
        }
    }
}
