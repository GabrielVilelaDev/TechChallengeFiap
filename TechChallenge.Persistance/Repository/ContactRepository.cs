using TechChallenge.Domain.Entities;
using TechChallenge.Persistance.Context;

namespace TechChallenge.Persistance.Repository
{
    public class ContactRepository(AppDbContext context) : BaseRepository<ContactEntity>(context)
    {
    }
}
