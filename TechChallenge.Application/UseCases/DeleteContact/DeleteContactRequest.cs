using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge.Application.UseCases.CreateContact;

namespace TechChallenge.Application.UseCases.DeleteContact
{
    public sealed record DeleteContactRequest(Guid Id) : IRequest<DeleteContactResponse>;
}
