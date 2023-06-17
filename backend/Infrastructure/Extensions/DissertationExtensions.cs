using System.Linq.Expressions;
using gerdisc.Infrastructure.Repositories.Dissertation;
using gerdisc.Models.Entities;
using gerdisc.Models.Enums;

namespace gerdisc.Infrastructure.Extensions
{
    public static class DissertationExtensions
    {
        public static IQueryable<DissertationEntity> FilterByUserRole(this IQueryable<DissertationEntity> query,IUserContext userContext)
        {
            switch (userContext.Role)
            {
                case RolesEnum.Professor:
                    return query.Where(d => d.ProjectId == userContext.UserId);
                case RolesEnum.Student:
                    return query.Where(d => d.StudentId == userContext.UserId);
                case RolesEnum.Administrator:
                default:
                    return query;
            }
        }
    }
}
