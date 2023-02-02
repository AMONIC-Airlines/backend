using Domain.Models;

namespace Database.Interfaces;

public interface IRoleRepository : IBaseRepository<Role>
{
    Task<Role?> GetByTitle(string title);
}
