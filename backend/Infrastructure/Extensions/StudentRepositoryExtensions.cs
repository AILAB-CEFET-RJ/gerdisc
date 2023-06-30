using gerdisc.Infrastructure.Providers;
using gerdisc.Models.Entities;
using gerdisc.Models.Enums;

namespace gerdisc.Infrastructure.Extensions
{
    public static class StudentRepositoryExtensions
    {
        public static IQueryable<StudentEntity> FilterByUserRole(this IQueryable<StudentEntity> query, IUserContext userContext)
        {
            switch (userContext.Role)
            {
                case RolesEnum.Professor:
                    return query.Where(p => p.Project == null ? false : p.Project.Orientations.Any(x => x.ProfessorId == userContext.UserId));
                case RolesEnum.Student:
                    return query.Where(p => p.Id == userContext.UserId);
                case RolesEnum.Administrator:
                    return query;
                case RolesEnum.ExternalResearcher:
                    return query.Where(d => d.Project.Orientations.Any(x => x.CoorientatorId == userContext.UserId));
                default:
                    return query.Where(d => false);
            }
        }
    }
}
