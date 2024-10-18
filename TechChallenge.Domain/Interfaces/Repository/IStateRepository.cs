using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces.Repository
{
    public interface IStateRepository<T> : IBaseRepository<T> where T : StateEntity { }
}
