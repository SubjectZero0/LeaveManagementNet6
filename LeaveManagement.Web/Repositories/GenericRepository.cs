using LeaveManagement.Web.Contracts;

namespace LeaveManagement.Web.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}