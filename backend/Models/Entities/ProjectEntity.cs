using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerdisc.Models.Entities;

namespace gerdisc.Models.Entities
{
    public record ProjectEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}