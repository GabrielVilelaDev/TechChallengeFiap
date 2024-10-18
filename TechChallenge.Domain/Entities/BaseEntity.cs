using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Domain.Entities
{
    public record BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public DateTimeOffset? InsertedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
    }
}
