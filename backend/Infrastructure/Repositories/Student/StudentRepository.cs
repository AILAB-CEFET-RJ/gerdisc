using System.Linq.Expressions;
using gerdisc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace gerdisc.Infrastructure.Repositories.Student
{
    public class StudentRepository : BaseRepository<StudentEntity>, IStudentRepository
    {
        public StudentRepository(ContexRepository dbContext) : base(dbContext)
        {
        }
    }
}