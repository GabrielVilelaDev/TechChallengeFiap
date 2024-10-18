using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Repository;
using TechChallenge.Persistance.Context;

namespace TechChallenge.Persistance.Repository
{
    public class RegionRepository(AppDbContext context, ReadOnlyDbContext readOnlyContext) : BaseRepository<RegionEntity>(context, readOnlyContext), IRegionRepository<RegionEntity> { }
}
