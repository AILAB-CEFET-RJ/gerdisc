using gerdisc.Models.Entities;

namespace gerdisc.Infrastructure.Repositories.Course
{
    public class CourseRepository : BaseRepository<CourseEntity>, ICourseRepository
    {
        public CourseRepository(ContexRepository dbContext) : base(dbContext)
        {
        }
    }
}