using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerdisc.Models.Entities;

namespace gerdisc.Models.Entities
{
    /// <summary>
    /// Represents a project in the system.
    /// </summary>
    public record ProjectEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the status of the project.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the list of professors associated with the project.
        /// </summary>
        public List<ProfessorEntity> Professors { get; set; }

        /// <summary>
        /// Gets or sets the list of students associated with the project.
        /// </summary>
        public List<StudentEntity> Students { get; set; }

        /// <summary>
        /// Gets or sets the list of dissertations associated with the project.
        /// </summary>
        public List<DissertationEntity> Dissertations { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectEntity"/> class.
        /// </summary>
        public ProjectEntity()
        {
            Professors = new List<ProfessorEntity>();
            Students = new List<StudentEntity>();
            Dissertations = new List<DissertationEntity>();
        }
    }
}