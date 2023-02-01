using Domain.Models;

namespace Domain.Logic.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmail(string phoneNumber);
    Task<List<User>> GetAll();
}