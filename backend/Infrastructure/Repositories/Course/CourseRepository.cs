using gerdisc.Models.Entities;

namespace gerdisc.Infrastructure.Repositories.Course
{
    /// <inheritdoc />
    public class CourseRepository : BaseRepository<CourseEntity>, ICourseRepository
    {
        public CourseRepository(ContexRepository dbContext) : base(dbContext)
        {
        }
    }
}