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

        public virtual async Task<StudentEntity> GetByIdAsync(Guid id)
        {
            return await _context.Students?.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<IEnumerable<StudentEntity>> FindAsync(Expression<Func<StudentEntity, bool>> predicate)
        {
            return await _context.Students?.Include(c => c.User).Where(predicate).ToListAsync();
        }
    }
}