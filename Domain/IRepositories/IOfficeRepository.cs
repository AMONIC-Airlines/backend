using Domain.Models;

namespace Domain.IRepositories;

public interface IOfficeRepository : IBaseRepository<Office>
{
    Task<Office?> GetByCountryId(int countryId);

    Task<Office?> GetByTitle(string title);

    Task<Office?> GetByPhone(string phone);

    Task<Office?> GetByContact(string contact);
}
