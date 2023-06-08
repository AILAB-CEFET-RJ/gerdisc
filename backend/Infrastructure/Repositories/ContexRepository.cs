using gerdisc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace gerdisc.Infrastructure.Repositories
{
    public class ContexRepository : DbContext
    {
        public string? DbUrl { get; }

        public DbSet<UserEntity> Users { get; set; } = null!;
        public DbSet<StudentEntity> Students { get; set; } = null!;
        public DbSet<ProfessorEntity> Professors { get; set; } = null!;
        public DbSet<CourseEntity> Courses { get; set; } = null!;
        public DbSet<ProjectEntity> Projects { get; set; } = null!;
        public DbSet<ExternalResearcherEntity> ExternalResearchers { get; set; } = null!;
        public DbSet<DissertationEntity> Dissertations { get; set; } = null!;
        public DbSet<ExtensionEntity> Extensions { get; set; } = null!;
        public DbSet<ProfessorProjectEntity> ProfessorProjects { get; set; } = null!;
        public DbSet<StudentCourseEntity> StudentCourses { get; set; } = null!;
        public DbSet<OrientationEntity> Orientations { get; set; } = null!;

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
