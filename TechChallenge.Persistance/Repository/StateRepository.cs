using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Repository;
using TechChallenge.Persistance.Context;

namespace TechChallenge.Persistance.Repository
{
    public class StateRepository(AppDbContext context, ReadOnlyDbContext readOnlyContext) : BaseRepository<StateEntity>(context, readOnlyContext), IStateRepository<StateEntity> { }
}
