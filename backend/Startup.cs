using gerdisc.Infrastructure.Repositories;
using gerdisc.Properties;
using gerdisc.Services.Course;
using gerdisc.Services.Interfaces;
using gerdisc.Services.Professor;
using gerdisc.Services.Project;
using gerdisc.Services.Student;
using gerdisc.Services.User;
using gerdisc.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace gerdisc
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
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
            });

            var settings = new AppSettings();
            var connectionString = $"Host={settings.PostgresServer};Username={settings.PostgresUser};Password={settings.PostgresPassword};Database={settings.PostgresDb}";

            var signingConfig = new SigningConfiguration(settings.SinginKey);

            services.AddNpgsql<ContexRepository>(connectionString);
            services.AddControllers();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<ISigningConfiguration>(signingConfig);
            services.AddSingleton<ISettings>(settings);
            services.AddSingleton<IRepository>(x => new Repository(x.GetService<ContexRepository>()));
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
        }

        public void Configure(IApplicationBuilder app)
        {
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
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
