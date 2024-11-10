using FluentValidation;

namespace TechChallenge.Application.UseCases.DeleteContact
{
    public sealed class DeleteContactValidator : AbstractValidator<DeleteContactRequest>
    {
        public DeleteContactValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Nome é obrigatório.");
        }
    }
}
