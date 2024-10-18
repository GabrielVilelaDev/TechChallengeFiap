using AutoMapper;
using MediatR;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Repository;

namespace TechChallenge.Application.UseCases.CreateContact
{
    public class CreateContactHandler(IContactRepository<ContactEntity> contactRepository, IMapper mapper) : IRequestHandler<CreateContactRequest, CreateContactResponse>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IContactRepository<ContactEntity> _contactRepository = contactRepository;

        public async Task<CreateContactResponse> Handle(CreateContactRequest request, CancellationToken cancellationToken)
        {
            ContactEntity entity = _mapper.Map<ContactEntity>(request);

            entity = await _contactRepository.Create(entity);

            return _mapper.Map<CreateContactResponse>(entity);
        }
    }
}
