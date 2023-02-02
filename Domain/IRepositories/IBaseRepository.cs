using Domain.Models;

namespace Domain.IRepositories;

public interface IBaseRepository<T>
{
    Task<T> Create(T Item);
    Task<T?> Get(int Id);
    Task<List<T>> GetAll();
    Task<T> Delete(int id);
    Task<T> Update(T Item);
    Task Save();
}
