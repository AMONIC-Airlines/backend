using Domain.Models;
using Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationContext _db;

    public RoleRepository(ApplicationContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(Role role)
    {
        if (_db.Roles != null)
        {
            await _db.Roles.AddAsync(role);
        }

        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Role> Get(int id)
    {
        return await _db.Roles.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Role>> Select()
    {
        return await _db.Roles.ToListAsync();
    }

    public async Task<bool> Delete(Role role)
    {
        _db.Roles.Remove(role);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Role> Update(Role role)
    {
        _db.Roles.Update(role);
        await _db.SaveChangesAsync();

        return role;
    }

    public async Task<Role> GetByTitle(string title)
    {
        return await _db.Roles.FirstOrDefaultAsync(x => x.Title == title);
    }


}
