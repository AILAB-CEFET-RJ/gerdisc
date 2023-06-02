using gerdisc.Infrastructure.Repositories;
using gerdisc.Services.Interfaces;

namespace Jobs
{
    public class StudentsFinishing : HangfireJobBase
    {
        private readonly IRepository _repository;
        private readonly IEmailSender _emailSender;

        public StudentsFinishing(ILogger<StudentsFinishing> logger, IRepository repository, IEmailSender emailSender) : base(logger)
        {
            _repository = repository;
            _emailSender = emailSender;
        }

        protected override async Task ProcessJobAsync()
        {
            var dangerousDate = DateTime.UtcNow.Date.AddDays(-30);

            var endOfCourseStudents = await _repository.Student.GetAllAsync(x => x.ProjectDefenceDate <= dangerousDate);

            foreach (var student in endOfCourseStudents)
            {
                _logger.LogInformation($"End of Course Student: {student.Id}");
                await _emailSender.SendEmail(student.User.Email, "Data de defesa proxima", "End of Course Student");
            }
        }
    }
}
