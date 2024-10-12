using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Domain.Entities
{
    public record BaseEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset InsertedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
    }
}
