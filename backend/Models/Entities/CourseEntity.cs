namespace gerdisc.Models.Entities
{
    /// <summary>
    /// Represents a course in the application.
    /// </summary>
    public record CourseEntity : BaseEntity
    {
        /// <summary>
        /// The name of the course.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The number of credits associated with the course.
        /// </summary>
        public int Credits { get; set; }

        /// <summary>
        /// The code assigned to the course.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Indicates whether the course is elective or not.
        /// </summary>
        public bool IsElective { get; set; }

        /// <summary>
        /// The concept assigned to the course.
        /// </summary>
        public string? Concept { get; set; }
    }

}