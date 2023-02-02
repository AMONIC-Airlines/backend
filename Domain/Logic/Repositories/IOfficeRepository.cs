using Domain.Models;

namespace Domain.Logic.Repositories;

public interface IOfficeRepository : IRepository<Office>
{
    Task<List<Office>> GetAll();
}
