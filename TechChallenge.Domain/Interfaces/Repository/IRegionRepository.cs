using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces.Repository
{
    public interface IRegionRepository<T> : IBaseRepository<T> where T : RegionEntity { }
}
