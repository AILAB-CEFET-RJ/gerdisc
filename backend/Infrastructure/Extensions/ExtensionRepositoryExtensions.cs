using gerdisc.Infrastructure.Providers;
using gerdisc.Models.Entities;
using gerdisc.Models.Enums;

namespace gerdisc.Infrastructure.Extensions
{
    public static class ExtensionRepositoryExtensions
    {
        public static IQueryable<ExtensionEntity> FilterByUserRole(this IQueryable<ExtensionEntity> query, IUserContext userContext)
        {
            switch (userContext.Role)
            {
                case RolesEnum.Student:
                    return query.Where(p => p.StudentId == userContext.UserId);
                default:
                    return query.Where(d => false);
            }
        }
    }
}
