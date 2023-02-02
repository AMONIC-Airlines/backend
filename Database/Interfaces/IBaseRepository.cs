using Domain.Models;

namespace Database.Interfaces;
public interface IBaseRepository<T>
{
    Task<bool> Create(T Item);
    Task<T> Get(int Id);
    Task<List<T>> Select();
    Task<bool> Delete(T Item);
    Task<T> Update(T Item);
}
