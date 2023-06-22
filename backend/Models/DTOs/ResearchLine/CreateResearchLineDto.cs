using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace gerdisc.Models.DTOs
{
    public class CreateResearchLineDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
    }
}
