using Domain.Models;
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

    public async Task<bool> Create(User user)
    {
        if (_db.Users != null)
        {
            await _db.Users.AddAsync(user);
        }

        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<User> Get(int Id)
    {
        return await _db.Users.FirstOrDefaultAsync(x => x.Id == Id);
    }

    public async Task<List<User>> Select()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task<bool> Delete(User user)
    {
        _db.Users.Remove(user);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<User> Update(User user)
    {
        _db.Users.Update(user);
        await _db.SaveChangesAsync();

        return user;
    }

    public async Task<User> GetByOfficeId(int officeId)
    {
        return await _db.Users.FirstOrDefaultAsync(x => x.OfficeId == officeId);
    }

    public async Task<User> GetByRoleId(int roleId)
    {
        return await _db.Users.FirstOrDefaultAsync(x => x.RoleId == roleId);
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _db.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));
    }

    public async Task<User> GetByFirstName(string firstName)
    {
        return await _db.Users.FirstOrDefaultAsync(x => x.FirstName.Equals(firstName));
    }

    public async Task<User> GetByLastName(string lastName)
    {
        return await _db.Users.FirstOrDefaultAsync(x => x.LastName.Equals(lastName));
    }

    public async Task<User> GetByBirthdate(DateOnly birthdate)
    {
        return await _db.Users.FirstOrDefaultAsync(x => x.Birthdate == birthdate);
    }

    public async Task<User> GetByActive(bool active)
    {
        return await _db.Users.FirstOrDefaultAsync(x => x.Active == active);
    }

    public async Task<User> GetByPassword(string password)
    {
        return await _db.Users.FirstOrDefaultAsync(x => x.Password == password);
    }

    public async Task<bool> GetByEmailAndPassword(string email, string password)
    {
        var emailResult = await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
        var passwordResult = await _db.Users.FirstOrDefaultAsync(x => x.Password == password);

        return emailResult != null && passwordResult != null;
    }


}
