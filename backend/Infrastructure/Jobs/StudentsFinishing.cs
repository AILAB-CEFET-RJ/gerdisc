using gerdisc.Infrastructure.Providers.Interfaces;
using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.Entities;

namespace Infrastructure.Jobs
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
            DateTime dangerousDate = DateTime.UtcNow.Date.AddDays(-30);

            var endOfCourseStudents = await _repository.Student.GetAllAsync(x => x.ProjectDefenceDate <= dangerousDate);

            foreach (var student in endOfCourseStudents)
            {
                _logger.LogInformation($"End of Course Student: {student.Id}");

                await NotifyStudentAsync(student);
                await UpdateStudentAsync(student);
            }
        }

        private async Task NotifyStudentAsync(StudentEntity student)
        {
            string emailSubject = "Data de defesa próxima";
            string emailBody = "End of Course Student";

            await _emailSender.SendEmail(student.User.Email, emailSubject, emailBody).ConfigureAwait(false);
        }

        private async Task UpdateStudentAsync(StudentEntity student)
        {
            student.LastNotification = DateTime.UtcNow;
            await _repository.Student.UpdateAsync(student).ConfigureAwait(false);
        }
    }
}
