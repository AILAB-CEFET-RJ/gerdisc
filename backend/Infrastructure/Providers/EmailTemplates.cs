using System.Text;
using saga.Models.Entities;

namespace Infrastructure.EmailTemplates
{
    public static class EmailTemplates
    {
        public static string WelcomeEmailTemplate(string resetPasswordPath, string token)
        {
            return $@"<html>
                        <body>
                            <p>Welcome to CEFET RJ Post Graduation!</p>
                            <p>To access your account, please set your password by clicking on the following link:</p>
                            <p><a href=""{resetPasswordPath}?token={token}"">{resetPasswordPath}?token={token}</a></p>
                        </body>
                    </html>";
        }

        public static string ResetPasswordEmailTemplate(string resetPasswordPath, string token)
        {
            return $@"<html>
                        <body>
                            <p>You have requested to reset your password. Please click on the following link to reset your password:</p>
                            <p><a href=""{resetPasswordPath}?token={token}"">{resetPasswordPath}?token={token}</a></p>
                        </body>
                    </html>";
        }

        public static string UpcomingDefenseEmailTemplate(string? firstName, string defenseTypeText, DateTime? qualificationDate, DateTime? defenseDate)
        {
            return $@"<html>
                        <body>
                            <p>Dear {firstName},</p>
                            <p>This is a reminder that your {defenseTypeText} date is approaching soon. Please make sure to prepare and be ready for your presentation.</p>
                            <p>If you have any questions or need any assistance, feel free to reach out to your mentor.</p>
                            <p>If you find that you need more time to adequately prepare, you may request an extension by contacting your academic advisor.</p>
                            <p>Your Qualification Date: {qualificationDate}</p>
                            <p>Your Defense Date: {defenseDate}</p>
                            <br>
                            <p>Best regards,</p>
                            <p>The Academic Team</p>
                        </body>
                    </html>";
        }

        public static string StudentsFinishingFromProfessorEmailTemplate(IGrouping<Guid, OrientationEntity> orientations, Dictionary<Guid, StudentEntity> students)
        {
            var body = new StringBuilder();

            body.AppendLine("The following students are finishing the course:");
            body.AppendLine("<table>");
            body.AppendLine("<tr>");
            body.AppendLine("<th>First Name</th>");
            body.AppendLine("<th>Last Name</th>");
            body.AppendLine("<th>Email</th>");
            body.AppendLine("<th>Defense Date</th>");
            body.AppendLine("<th>Qualification Date</th>");
            body.AppendLine("</tr>");

            foreach (var orientation in orientations)
            {
                if (students.TryGetValue(orientation.StudentId, out var student))
                {
                    body.AppendLine("<tr>");
                    body.AppendLine($"<td>{student.User?.FirstName}</td>");
                    body.AppendLine($"<td>{student.User?.LastName}</td>");
                    body.AppendLine($"<td>{student.User?.Email}</td>");
                    body.AppendLine($"<td>{student.ProjectDefenceDate}</td>");
                    body.AppendLine($"<td>{student.ProjectQualificationDate}</td>");
                    body.AppendLine("</tr>");
                }
            }

            body.AppendLine("</table>");
            return body.ToString();
        }
    }
}
