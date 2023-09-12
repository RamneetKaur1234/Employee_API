using System.Linq.Expressions;

namespace WebApplication_FirstAPI_Employee.Repository.iRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        T Find(int id);
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T FirstorDefault(Expression<Func<T, bool>> filter = null,
            string includeProperties = null);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null);
    }
}
