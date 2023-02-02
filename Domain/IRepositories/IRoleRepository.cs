using Domain.Models;

namespace Domain.IRepositories;

public interface IRoleRepository : IBaseRepository<Role>
{
    Task<Role?> GetByTitle(string title);
}
