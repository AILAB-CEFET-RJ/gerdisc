using System.Linq.Expressions;
using gerdisc.Infrastructure.Repositories.Dissertation;
using gerdisc.Models.Entities;
using gerdisc.Models.Enums;

namespace gerdisc.Infrastructure.Extensions
{
    public static class DissertationExtensions
    {
        public static Expression<Func<DissertationEntity, bool>> FilterByUserRole(IUserContext userContext)
        {
            switch (userContext.Role)
            {
                case RolesEnum.Professor:
                    return d => d.ProjectId == userContext.UserId;
                case RolesEnum.Student:
                    return d => d.StudentId == userContext.UserId;
                case RolesEnum.Administrator:
                default:
                    return d => true;
            }
        }
    }
}
