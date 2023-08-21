namespace WebApplication_FirstAPI_Employee.Repository.iRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        T Find(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
