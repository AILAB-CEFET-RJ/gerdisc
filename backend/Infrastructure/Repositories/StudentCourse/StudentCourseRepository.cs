using gerdisc.Models.Entities;

namespace gerdisc.Infrastructure.Repositories.StudentCourse
{
    public class StudentCourseRepository : BaseRepository<StudentCourseEntity>, IStudentCourseRepository
    {
        public StudentCourseRepository(ContexRepository dbContext) : base(dbContext)
        {
        }
    }
}