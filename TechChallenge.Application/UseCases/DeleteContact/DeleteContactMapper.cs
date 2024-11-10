using AutoMapper;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.UseCases.DeleteContact
{
    public sealed class DeleteContactMapper : Profile
    {
        public DeleteContactMapper()
        {
            CreateMap<DeleteContactRequest, ContactEntity>().ReverseMap();
            CreateMap<DeleteContactResponse, ContactEntity>().ReverseMap();
        }
    }
}
