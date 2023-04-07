using gerdisc.Models.Entities;

namespace gerdisc.Infrastructure.Repositories.Student
{
    public class StudentRepository : BaseRepository<StudentEntity>, IStudentRepository
    {
        public StudentRepository(ContexRepository dbContext) : base(dbContext)
        {
        }
    }
}