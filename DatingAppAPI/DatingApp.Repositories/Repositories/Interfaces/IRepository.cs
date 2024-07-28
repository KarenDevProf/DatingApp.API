using System.Linq.Expressions;

namespace DatingApp.Repositories.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        Task<List<T>> GetAllAsync();
        T Delete(T entity);
        Task<int> SaveChangesAsync();
        void SetCurrentValues(T existingParent, object orderRequest);
    }
}
