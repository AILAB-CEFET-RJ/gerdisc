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

        public override async Task<StudentEntity?> GetSingleAsync(int id)
        {
            return await _context.Students?.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<StudentEntity?> GetSingleAsync(Expression<Func<StudentEntity, bool>> predicate)
        {
            return await _context.Students?.Include(c => c.User).FirstOrDefaultAsync(predicate);
        }

        public override async Task<IEnumerable<StudentEntity>> FindByAsync(Expression<Func<StudentEntity, bool>> predicate)
        {
            return await _context.Students?.Include(c => c.User).Where(predicate).ToListAsync();
        }
    }
}