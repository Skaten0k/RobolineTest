using RobolineTest.Domain.Core;

namespace RobolineTest.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Create(T product);
        Task Update(T product);
        Task Delete(int id);
    }
}
