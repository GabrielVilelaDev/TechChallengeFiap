using AutoMapper;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.UseCases.CreateContact
{
    public sealed class CreateContactMapper : Profile
    {
        public CreateContactMapper()
        {
            CreateMap<CreateContactRequest, ContactEntity>().ReverseMap();
            CreateMap<CreateContactResponse, ContactEntity>().ReverseMap();
        }
    }
}
