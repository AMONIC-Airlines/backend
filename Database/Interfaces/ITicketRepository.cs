using Database.Models;

namespace Database.Interfaces;

public interface ITicketRepository : IBaseRepository<Ticket>
{
    Task<List<Ticket>> GetByUserId(int userId);
}
