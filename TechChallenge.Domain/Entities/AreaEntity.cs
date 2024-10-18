using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Domain.Entities
{
    public record AreaEntity : BaseEntity
    {
        [Required (ErrorMessage = "O Prefixo é obrigatório")]
        [StringLength(5)]
        public string? Prefix { get; set; }
        [Required (ErrorMessage = "O Estado é obrigatório")]
        public Guid IdState { get; set; }
        public Guid? IdRegion { get; set; }

        #region Relationship
        public virtual StateEntity? State { get; set; }
        public virtual RegionEntity? Region { get; set; }
        public ICollection<ContactEntity>? ListContact { get; set; } 
        #endregion
    }
}
