using gerdisc.Properties;
using gerdisc.Infrastructure.Repositories;
using gerdisc.Settings;
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
var settings = new Settings();
var connectionString = $"Host={settings.PostgresServer};Username={settings.PostgresUser};Password={settings.PostgresPassword};Database={settings.PostgresDb}";
var singingConfig = new SingingConfiguration(settings.SinginKey);
builder.Services.AddNpgsql<ContexRepository>(connectionString);
builder.Services.AddControllers();
builder.Services.AddSingleton<ISingingConfiguration>(x => singingConfig);
builder.Services.AddSingleton<ISettings, Settings>(x => settings);
builder.Services.AddSingleton<IRepository>(
    x => new Repository(x.GetService<ContexRepository>()));
builder.Services.AddAuthorization();
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