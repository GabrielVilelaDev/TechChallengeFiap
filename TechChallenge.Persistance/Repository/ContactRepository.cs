using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Repository;
using TechChallenge.Persistance.Context;

namespace TechChallenge.Persistance.Repository
{
    public class ContactRepository(AppDbContext context, ReadOnlyDbContext readOnlyContext) : BaseRepository<ContactEntity>(context, readOnlyContext), IContactRepository<ContactEntity>
    {
        public async Task<ContactEntity?> GetByPhoneNumber(string phoneNumber)
        {
            IEnumerable<ContactEntity> entityReturn = await base.Get(entityFilter: new() { PhoneNumber = phoneNumber },
                attributesToIgnore: null,
                useLikeOperationInStrings: false,
                considerNullAttributes: false,
                page: 1,
                pageSize: 1);
            return entityReturn.FirstOrDefault();
        }
    }
}
