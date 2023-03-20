using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class SecurityRequirementsOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var authAttributes = context.MethodInfo.GetCustomAttributes(true)
            .OfType<Microsoft.AspNetCore.Authorization.AuthorizeAttribute>()
            .Distinct();

        if (authAttributes.Any())
        {
            var requirements = new List<OpenApiSecurityRequirement>();
            foreach (var authAttribute in authAttributes)
            {
                var requirement = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new[] { authAttribute.Policy ?? "" }
                    }
                };
                requirements.Add(requirement);
            }

            operation.Security = requirements;
        }
    }
}
