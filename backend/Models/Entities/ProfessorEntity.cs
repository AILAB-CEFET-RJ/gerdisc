using System.ComponentModel.DataAnnotations;

namespace gerdisc.Models.Entities
{
    public record ProfessorEntity : BaseEntity
    {
        /// <summary>
        /// The user ID of the professor.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The SIAPE (System for Electronic Management of Educational Documentation) number of the professor.
        /// </summary>
        public string? Siape { get; set; }
    }
}