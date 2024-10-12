using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Domain.Entities
{
    public record ContactEntity: BaseEntity
    {
        public string? Name { get; set; }
        public string? Prefix { get; set; }
        public string? DDD { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
