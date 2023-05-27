using gerdisc.Infrastructure.Repositories;

namespace Jobs
{
    public class StudentsFinishing : HangfireJobBase
    {
        private readonly IRepository _repository;

        public StudentsFinishing(ILogger<StudentsFinishing> logger, IRepository studentRepository) : base(logger)
        {
            _repository = studentRepository;
        }

        protected override async Task ProcessJobAsync()
        {
            var dangerousDate = (DateTime.Today).AddDays(-30).ToUniversalTime();

            var endOfCourseStudents = await _repository.Student.GetAllAsync(x => x.ProjectDefenceDate <= dangerousDate);

            foreach (var student in endOfCourseStudents)
            {
                Console.WriteLine($"End of Course Student: {student.Id}");
            }
        }
    }
}
