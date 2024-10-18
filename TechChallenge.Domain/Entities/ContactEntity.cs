using System.ComponentModel.DataAnnotations;
using TechChallenge.Domain.Attributes;

namespace TechChallenge.Domain.Entities
{
    public record ContactEntity: BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        [BrazilPhoneNumber]
        public string? PhoneNumber { get; set; }
        public Guid IdArea { get; set; }

        #region Relationship
        public virtual AreaEntity? Area { get; set; }
        #endregion
    }
}
