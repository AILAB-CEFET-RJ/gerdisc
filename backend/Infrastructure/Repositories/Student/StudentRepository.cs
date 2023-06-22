using System.Linq.Expressions;
using gerdisc.Infrastructure.Extensions;
using gerdisc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace gerdisc.Infrastructure.Repositories.Student
{
    /// <inheritdoc />
    public class StudentRepository : BaseRepository<StudentEntity>, IStudentRepository
    {
        public StudentRepository(ContexRepository dbContext) : base(dbContext)
        {
        }

        /// <inheritdoc />
        public override async Task<StudentEntity?> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .FirstOrDefaultAsync(e => e.UserId == id);
        }

        /// <inheritdoc />
        public override async Task<StudentEntity?> GetByIdAsync(
            Guid id,
            params Expression<Func<StudentEntity, object>>[] includeProperties)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .IncludeMultiple(includeProperties)
                .SingleOrDefaultAsync(p => p.UserId == id);
        }

        /// <inheritdoc />
        public override async Task DeactiveByIdAsync(Guid id)
        {
            StudentEntity? entityToDelete = await _dbSet.FirstAsync(x => x.UserId == id);
            if (entityToDelete == null)
                throw new ArgumentNullException(nameof(entityToDelete));

            entityToDelete.IsDeleted = true;
            await UpdateAsync(entityToDelete);
        }
    }
}