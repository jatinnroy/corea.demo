using Microsoft.EntityFrameworkCore;
using demo.Database;
using demo.Repositories.IRepositories;
using System.Linq.Expressions;

namespace demo.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DemoDBContext _demoDBContext;
        public GenericRepository(DemoDBContext demoDBContext)
        {
            _demoDBContext = demoDBContext;
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await _demoDBContext.Set<T>().ToListAsync();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _demoDBContext.Set<T>().Where(expression);
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _demoDBContext.Set<T>().FindAsync(id);
        }
        public async void AddAsync(T entity)
        {
            await _demoDBContext.Set<T>().AddAsync(entity);
        }
        public async void AddRangeAsync(IEnumerable<T> entities)
        {
            await _demoDBContext.Set<T>().AddRangeAsync(entities);
        }
        public void Update(T entity)
        {
            _demoDBContext.Set<T>().Update(entity);
        }
        public void UpdateRange(IEnumerable<T> entities)
        {
            _demoDBContext.Set<T>().UpdateRange(entities);
        }
        public void Delete(T entity)
        {
            _demoDBContext.Set<T>().Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            _demoDBContext.Set<T>().RemoveRange(entities);
        }
    }
}
