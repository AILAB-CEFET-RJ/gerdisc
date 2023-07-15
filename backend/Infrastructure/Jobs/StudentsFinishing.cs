using System.Text;
using saga.Infrastructure.Providers.Interfaces;
using saga.Infrastructure.Repositories;
using saga.Models.Entities;

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
            var orientations = await _repository
                .Orientation
                .GetAllAsync(x => endOfCourseStudents.Select(x => x.UserId).Contains(x.StudentId), x => x.Student, x => x.Professor);
            foreach (var orientation in orientations.GroupBy(x => x.ProfessorId))
            {
                if(orientation is not null)
                    NotifyProfessorAsync(orientation);
            }

            foreach (var student in endOfCourseStudents)
            {
                _logger.LogInformation($"End of Course Student: {student.Id}");

                await NotifyStudentAsync(student);
                await UpdateStudentAsync(student);
            }
        }

        private async Task NotifyProfessorAsync(IGrouping<Guid, OrientationEntity> groupedOrientations)
        {
            string emailSubject = "Data de defesa próxima";
            var body = new StringBuilder();

            body.AppendLine("The following students are finishing the course:");
            foreach (var orientation in groupedOrientations)
            {
                if (orientation.Student is not null)
                {
                    body.AppendLine($"- {orientation.Student.FirstName + orientation.Student.LastName} ({orientation.Student.Email})");
                }
            }

            string professorEmail = groupedOrientations?.FirstOrDefault()?.Professor?.Email;
            await _emailSender.SendEmail(professorEmail, emailSubject, body.ToString()).ConfigureAwait(false);
        }

        private async Task NotifyStudentAsync(StudentEntity student)
        {
            string emailSubject = "Upcoming Defense Date";
            string emailBody = $"Dear {student.User.FirstName},\n\nThis is a reminder that your defense date is approaching soon. Please make sure to prepare and be ready for your presentation. If you have any questions or need any assistance, feel free to reach out to your mentor.\n\nIf you find that you need more time to adequately prepare, you may request an extension by contacting your academic advisor or the department office.\n\nBest regards,\nThe Academic Team";

            await _emailSender.SendEmail(student.User.Email, emailSubject, emailBody).ConfigureAwait(false);
        }

        private async Task UpdateStudentAsync(StudentEntity student)
        {
            student.LastNotification = DateTime.UtcNow;
            await _repository.Student.UpdateAsync(student).ConfigureAwait(false);
        }
    }
}
