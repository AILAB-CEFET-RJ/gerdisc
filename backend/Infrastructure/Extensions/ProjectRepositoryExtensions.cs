using System.Linq.Expressions;
using gerdisc.Infrastructure.Repositories.ProfessorProject;
using gerdisc.Infrastructure.Repositories.Project;
using gerdisc.Models.Entities;
using gerdisc.Models.Enums;

namespace gerdisc.Infrastructure.Extensions
{
    public static class ProjectRepositoryExtensions
    {
        public static IQueryable<ProjectEntity> FilterByUserRole(this IQueryable<ProjectEntity> query, IUserContext userContext)
        {
            switch (userContext.Role)
            {
                case RolesEnum.Professor:
                    return query.Where(project => project.ProfessorProjects.Any(professor => professor.ProfessorId == userContext.UserId));
                case RolesEnum.Student:
                    return query.Where(p => p.Students.Any(student => student.User.Id == userContext.UserId));
                case RolesEnum.Administrator:
                default:
                    return query;
            }
        }
    }
}
