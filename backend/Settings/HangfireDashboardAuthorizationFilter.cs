using System.Security.Claims;
using gerdisc.Models.Enums;
using Hangfire.Dashboard;

namespace gerdisc.Settings;
public class HangfireDashboardAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        var httpContext = context.GetHttpContext();

        if (httpContext.User.Identity.IsAuthenticated)
        {
            string? role = httpContext.User?.FindFirst(ClaimTypes.Role)?.Value;
            if (Enum.TryParse<RolesEnum>(role, ignoreCase: true, out var enumValue) &&
                enumValue == RolesEnum.Administrator)
            {
                return true;
            }
        }

        return false;
    }
}