using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces.Repository
{
    public interface IContactRepository<T> : IBaseRepository<T> where T : ContactEntity
    {
        Task<T?> GetByPhoneNumber(string phoneNumber);
    }
}
