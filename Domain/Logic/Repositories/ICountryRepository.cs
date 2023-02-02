using Domain.Models;

namespace Domain.Logic.Repositories;
public interface ICountryRepository : IRepository<Country>
{
    Task<List<Country>> GetAll();
}
