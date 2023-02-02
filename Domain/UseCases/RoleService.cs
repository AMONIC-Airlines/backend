using Domain.Logic;
using Domain.Logic.Repositories;
using Domain.Models;

namespace Domain.UseCases;

public class RoleService
{
    private IRoleRepository _db;

    public RoleService(IRoleRepository db)
    {
        _db = db;
    }

    public async Task<Result<Role>> GetRole(int id)
    {
        try
        {
            var success = await _db.Get(id);

            if (success is null)
            {
                return Result.Fail<Role>("Role doesn't exist.");
            }

            return Result.Ok<Role>(success);
        }
        catch (Exception) 
        {
            return Result.Exception<Role>();
        }
    }

    public async Task<Result<Role>> DeleteRole(int id)
    {
        try
        {
            var success = await _db.Delete(id);

            return Result.Ok<Role>(success);   
        }
        catch (Exception) 
        {
            return Result.Exception<Role>();
        }
    }

    public async Task<Result<Role>> UpdateRole(Role role)
    {
        try
        {
            var success = await _db.Update(role);
            
            return Result.Ok<Role>(success);    
        }
        catch (Exception)
        {
            return Result.Exception<Role>();
        }
    }

    public async Task<Result<Role>> CreateRole(Role role)
    {
        try
        {
            var item = await _db.Get(role.Id);

            if (item is not null)
            {
                return Result.Fail<Role>("Role already exists");
            }

            var success = await _db.Create(role);

            return Result.Ok<Role>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Role>();
        }
    }

    public async Task<Result<List<Role>>> GetAllRoles()
    {
        try
        {
            var success = await _db.GetAll();

            return Result.Ok<List<Role>>(success);
        }
        catch (Exception)
        {
            return Result.Exception<List<Role>>();
        }
    }
}
