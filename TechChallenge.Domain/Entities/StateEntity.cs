using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Domain.Entities
{
    public record StateEntity : BaseEntity
    {
        [Required(ErrorMessage = "A Descrição é obrigatório")]
        [StringLength(150)]
        public string? Description { get; set; }
        [Required(ErrorMessage = "A Sigla é obrigatório")]
        [StringLength(150)]
        public string? Sigla { get; set; }

        #region Relationship
        public ICollection<AreaEntity>? ListArea { get; set; }
        #endregion
    }
}
