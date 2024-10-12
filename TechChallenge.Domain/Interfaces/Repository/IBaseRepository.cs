using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> Get(T entityFilter, List<string>? attributesToIgnore, bool useLikeOperationInStrings, bool considerNullAttributes, int page, int pageSize);
        Task<T> Create(T entity);
        Task<T> Update(Guid id, T entity);
        Task<T> Delete(Guid id);
        Task<bool> Exists(Guid id);
        Task<bool> Exists(T entityFilter, List<string>? attributesToIgnore, bool useLikeOperationInStrings, bool considerNullAttributes);
        Task<int> Count(T entityFilter, List<string>? attributesToIgnore, bool useLikeOperationInStrings, bool considerNullAttributes);
    }
}
