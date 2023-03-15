using System.Security.Cryptography;
using System.Text;
using gerdisc.Propierties;
using gerdisc.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gerdisc", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddControllers();
builder.Services.AddSingleton<IUnitOfWork>(x => new UnitOfWork("localhost","postgres","example","my_database"));
builder.Services.AddAuthorization();
var publicKey = ;
var singingConfig = new SingingConfiguration(publicKey);
builder.Services.AddSingleton<ISingingConfiguration>(x => singingConfig);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = singingConfig.Key
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gerdisc V1");
    c.DefaultModelsExpandDepth(-1);
    c.DocumentTitle = "Gerdisc Api Documentation";
    c.EnableDeepLinking();
    c.DisplayRequestDuration();
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();