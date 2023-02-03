using Database.Models;

namespace Database.Interfaces;

public interface ICabintypeRepository : IBaseRepository<Cabintype>
{
    Task<Cabintype?> GetByName(string name);
}
