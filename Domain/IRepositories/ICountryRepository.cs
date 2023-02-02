using Domain.Models;

namespace Domain.IRepositories;

public interface ICountryRepository : IBaseRepository<Country>
{
    Task<Country?> GetByName(string name);
}
