using System.Linq.Expressions;
using gerdisc.Infrastructure.Repositories.Orientation;
using gerdisc.Models.Entities;
using gerdisc.Models.Enums;

namespace gerdisc.Infrastructure.Extensions
{
    public static class OrientationExtensions
    {
        public static IQueryable<OrientationEntity> FilterByUserRole(this IQueryable<OrientationEntity> query,IUserContext userContext)
        {
            switch (userContext.Role)
            {
                case RolesEnum.Professor:
                    return query.Where(d => d.ProfessorId == userContext.UserId | d.CoorientatorId == userContext.UserId);
                case RolesEnum.Student:
                    return query.Where(d => d.Dissertation.StudentId == userContext.UserId);
                case RolesEnum.Administrator:
                default:
                    return query;
            }
        }
    }
}
