using System.Security.Claims;
using gerdisc.Models.Enums;

public class UserContextMiddleware
{
    private readonly RequestDelegate _next;

    public UserContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IUserContext userContext)
    {
        string? userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        string? role = context.User?.FindFirst(ClaimTypes.Role)?.Value;
        var user = Guid.TryParse(userId, out Guid id);
        if (Enum.TryParse<RolesEnum>(role, out var enumValue))
        // Set the user information in the UserContext
        userContext.UserId = id;
        userContext.Role = enumValue;

        // Call the next middleware in the pipeline
        await _next(context);
    }
}
