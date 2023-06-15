using System.Security.Claims;

public class UserContextMiddleware
{
    private readonly RequestDelegate _next;

    public UserContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IUserContext userContext)
    {
        string userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        string role = context.User?.FindFirst(ClaimTypes.Role)?.Value;

        // Set the user information in the UserContext
        userContext.UserId = userId;
        userContext.Role = role;

        // Call the next middleware in the pipeline
        await _next(context);
    }
}
