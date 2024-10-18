using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Repository;
using TechChallenge.Persistance.Context;

namespace TechChallenge.Persistance.Repository
{
    public class AreaRepository(AppDbContext context, ReadOnlyDbContext readOnlyContext) : BaseRepository<AreaEntity>(context, readOnlyContext), IAreaRepository<AreaEntity> { }
}
