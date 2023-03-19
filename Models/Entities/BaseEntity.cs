using System.ComponentModel.DataAnnotations;

namespace gerdisc.Models.Entities
{
    public record BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}