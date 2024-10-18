using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Domain.Entities
{
    public record RegionEntity : BaseEntity
    {
        [Required(ErrorMessage = "A Descrição é obrigatório")]
        [StringLength(150)]
        public string? Description { get; set; }

        #region Relationship
        public ICollection<AreaEntity>? ListArea { get; set; }
        #endregion
    }
}
