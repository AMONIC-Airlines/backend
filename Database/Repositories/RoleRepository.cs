using Database.Models;
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

    public async Task<Role> Create(Role role)
    {
        await _db.Roles.AddAsync(role);

        await Save();

        return role;
    }

    public async Task<Role?> Get(int id)
    {
        return await _db.Roles.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Role>> GetAll()
    {
        return await _db.Roles.ToListAsync();
    }

    public async Task<Role> Delete(int id)
    {
        var role = await _db.Roles.AsNoTracking().FirstAsync(x => x.Id == id);

        _db.Roles.Remove(role);
        await Save();

        return role;
    }

    public async Task<Role> Update(Role role)
    {
        _db.Roles.Update(role);
        await Save();

        return role;
    }

    public async Task<Role?> GetByTitle(string title)
    {
        return await _db.Roles.AsNoTracking().FirstOrDefaultAsync(x => x.Title == title);
    }

    public async Task Save()
    {
        await _db.SaveChangesAsync();
    }
}
