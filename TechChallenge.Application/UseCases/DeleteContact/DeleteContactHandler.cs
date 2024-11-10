using AutoMapper;
using MediatR;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Repository;

namespace TechChallenge.Application.UseCases.DeleteContact
{
    public class DeleteContactHandler(IContactRepository<ContactEntity> contactRepository, IMapper mapper) : IRequestHandler<DeleteContactRequest, DeleteContactResponse>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IContactRepository<ContactEntity> _contactRepository = contactRepository;

        public async Task<DeleteContactResponse> Handle(DeleteContactRequest request, CancellationToken cancellationToken)
        {
            ContactEntity entity = await _contactRepository.Delete(request.Id);

            return _mapper.Map<DeleteContactResponse>(entity);
        }
    }
}
