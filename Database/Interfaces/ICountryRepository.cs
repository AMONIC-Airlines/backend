using Domain.Models;

namespace Database.Interfaces;
public interface ICountryRepository : IBaseRepository<Country>
{
    Task<Country> GetByName(string name);
}
