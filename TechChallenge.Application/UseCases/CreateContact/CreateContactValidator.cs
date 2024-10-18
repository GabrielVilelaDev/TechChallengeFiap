using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Application.UseCases.CreateContact
{
    public sealed class CreateContactValidator : AbstractValidator<CreateContactRequest>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(80)
                .WithMessage("Nome deve conter no máximo 80 caracteres.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefone é obrigatório.")
                .MaximumLength(11).Matches(@"^\(?\d{2}\)?[\s-]?9?\d{4}[\s-]?\d{4}$")
                .WithMessage("O número de telefone deve conter 11 dígitos sendo o prefixo (2 dígitos) seguido pelo número (9 dígitos).");
        }
    }
}
