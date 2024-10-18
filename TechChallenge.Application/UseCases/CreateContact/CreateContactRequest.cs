using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Application.UseCases.CreateContact
{
    public sealed record CreateContactRequest(string Name, string PhoneNumber, Guid IdArea) : IRequest<CreateContactResponse>;
}
