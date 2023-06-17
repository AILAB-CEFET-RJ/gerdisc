using gerdisc.Infrastructure.Providers;
using gerdisc.Infrastructure.Providers.Interfaces;
using gerdisc.Infrastructure.Repositories;
using gerdisc.Properties;
using gerdisc.Services;
using gerdisc.Services.Interfaces;
using gerdisc.Settings;
using Hangfire;
using Hangfire.PostgreSql;
using Infrastructure.Jobs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace gerdisc
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddEndpointsApiExplorer();
            services.AddAuthorization();

            services.AddSwaggerGen(c =>
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
                c.DocumentFilter<BasePathDocumentFilter>(); 
            });

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            var settings = new AppSettings();
            var connectionString = $"Host={settings.PostgresServer};Username={settings.PostgresUser};Password={settings.PostgresPassword};Database={settings.PostgresDb}";

            var signingConfig = new SigningConfiguration(settings.SinginKey);

            services.AddDbContext<ContexRepository>(options =>
            {
                options.UseNpgsql(connectionString);
            }, ServiceLifetime.Scoped);
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<IExternalResearcherService, ExternalResearcherService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDissertationService, DissertationService>();
            services.AddScoped<IExtensionService, ExtensionService>();
            services.AddScoped<IUserContext, UserContext>();
            services.AddSingleton<ISigningConfiguration>(signingConfig);
            services.AddSingleton<ISettings>(settings);
            services.AddSingleton<IRepository>(x => new Repository(x.GetService<ContexRepository>()));
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddAuthorization();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingConfig.Key
                    };
                });

            services.AddHangfireServer();
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(connectionString));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UsePathBase("/gerdisc");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/gerdisc/swagger/v1/swagger.json", "Gerdisc V1");
                c.DefaultModelsExpandDepth(-1);
                c.RoutePrefix = string.Empty;
                c.DocumentTitle = "Gerdisc API Documentation";
                c.EnableDeepLinking();
                c.DisplayRequestDuration();
            });

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHangfireDashboard();
            app.UseMiddleware<UserContextMiddleware>();
            app.UseMiddleware<LogRequest>();
            RecurringJob.AddOrUpdate<StudentsFinishing>("daily-job", x => x.ExecuteAsync(null), Cron.Daily);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHangfireDashboard();
            });
        }
    }
}
