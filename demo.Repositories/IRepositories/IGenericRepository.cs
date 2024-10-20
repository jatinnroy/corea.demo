using demo.Database;
using System.Linq.Expressions;

namespace demo.Repositories.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> ListAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int id);
        void AddAsync(T entity);
        void AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
