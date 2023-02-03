using Database.Models;
using Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _db;

    public UserRepository(ApplicationContext db)
    {
        _db = db;
    }

    public async Task<User> Create(User user)
    {
        await _db.Users.AddAsync(user);

        await Save();

        return user;
    }

    public async Task<User?> Get(int Id)
    {
        return await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
    }

    public async Task<List<User>> GetAll()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task<User> Delete(int id)
    {
        var user = await _db.Users.AsNoTracking().FirstAsync(x => x.Id == id);

        _db.Users.Remove(user);
        await Save();

        return user;
    }

    public async Task<User> Update(User user)
    {
        _db.Users.Update(user);
        await Save();

        return user;
    }

    public async Task<User?> GetByOfficeId(int officeId)
    {
        return await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.OfficeId == officeId);
    }

    public async Task<User?> GetByRoleId(int roleId)
    {
        return await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.RoleId == roleId);
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Equals(email));
    }

    public async Task<User?> GetByFirstName(string firstName)
    {
        return await _db.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.FirstName!.Equals(firstName));
    }

    public async Task<User?> GetByLastName(string lastName)
    {
        return await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.LastName.Equals(lastName));
    }

    public async Task<User?> GetByBirthdate(DateOnly birthdate)
    {
        return await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Birthdate == birthdate);
    }

    public async Task<User?> GetByActive(bool active)
    {
        return await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Active == active);
    }

    public async Task<User?> GetByPassword(string password)
    {
        return await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Password == password);
    }

    public async Task Save()
    {
        await _db.SaveChangesAsync();
    }
}
