using System.Linq.Expressions;

namespace HRMApp.Data
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        Task DeleteAsync(long id);
        Task<bool> SaveChangesAsync();
    }
}
