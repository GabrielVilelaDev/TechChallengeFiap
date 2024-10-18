using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces.Repository
{
    public interface IAreaRepository<T> : IBaseRepository<T> where T : AreaEntity { }
}
