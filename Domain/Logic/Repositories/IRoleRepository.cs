using Domain.Models;

namespace Domain.Logic.Repositories;

public interface IRoleRepository : IRepository<Role>
{
    Task<List<Role>> GetAll();
}
