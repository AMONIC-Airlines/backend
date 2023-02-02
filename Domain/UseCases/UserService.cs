using Domain.Logic;
using Domain.Logic.Repositories;
using Domain.Models;

namespace Domain.UseCases;
public class UserService
{
    private IUserRepository _db;

    public UserService(IUserRepository db)
    { 
        _db = db; 
    }

    public async Task<Result<User>> GetUser(int id)
    {
        try
        {
            var success = await _db.Get(id);

            if (success is null)
            {
                return Result.Fail<User>("User doesn't exist.");
            }

            return Result.Ok<User>(success);
        }
        catch (Exception)
        {
            return Result.Exception<User>("Failed to get user");
        }

    }

    public async Task<Result<User>> Registration(User user)
    {
        try
        { 
            var item = await _db.GetByEmail(user.Email!);

            if (item is not null)
            {
                return Result.Fail<User>("Email is already taken.");
            }

            user.Password = User.GeneratePassword(user.Password!);

            var success = await _db.Create(user);

            return Result.Ok<User>(success);
        }
        catch (Exception)
        {
            return Result.Exception<User>("Failed to register");
        }
    }

    public async Task<Result<User>> Authorization(string email, string password)
    {
        try
        {
            var success = await _db.GetByEmail(email);

            if (success is null)
            {
                return Result.Fail<User>("User doesn't exist.");
            }

            var generatedPassword = User.GeneratePassword(password);

            if (success.Password != generatedPassword)
            {
                return Result.Fail<User>("Wrong Password.");
            }

            return Result.Ok<User>(success);
        }
        catch (Exception)
        {
            return Result.Exception<User>("Failed to pass authorization");
        }
    }

    public async Task<Result<User>> UpdateUser(User user)
    {
        try
        {
            var success = await _db.Update(user);

            return Result.Ok<User>(success);
        }
        catch (Exception ex)
        {
            return Result.Exception<User>("Failed to update user");
        }
    }

    public async Task<Result<User>> DeleteUser(int id)
    {
        try
        {
            var success = await _db.Delete(id);

            return Result.Ok<User>(success);  
        }
        catch (Exception ex)
        {
            return Result.Exception<User>("Failed to delete user");
        }
    }

    public async Task<Result<User>> ActivateUser(int id)
    {
        try
        {
            var success = await _db.Get(id);

            if (success is null)
            {
                return Result.Fail<User>("User doesn't exist.");
            }

            success.Active = true;

            var updated = await _db.Update(success!);

            return Result.Ok<User>(updated);
        }
        catch (Exception ex)
        {
            return Result.Exception<User>("Failed to activate user");
        }
    }

    public async Task<Result<User>> DeactivateUser(int id)
    {
        try
        {
            var success = await _db.Get(id);

            if (success is null)
            {
                return Result.Fail<User>("UserService.DeactivateUser: User doesn't exist.");
            }

            success.Active = false;

            var updated = await _db.Update(success!);

            return Result.Ok<User>(updated);
        }
        catch (Exception ex)
        {
            return Result.Exception<User>("Failed to deactivate user");
        }
    }

    public async Task<Result<User>> ChangeRole(int id, int roleId)
    {
        try
        {
            var success = await _db.Get(id);

            if (success is null)
            {
                return Result.Fail<User>("User doesn't exist.");
            }

            success.RoleId= roleId;

            var updated = await _db.Update(success!);

            return Result.Ok<User>(updated);
        }
        catch (Exception ex)
        {
            return Result.Exception<User>("Failed to change user's role");
        }
    }

    public async Task<Result<List<User>>> GetAllUsers()
    {
        try
        {
            var success = await _db.GetAll();

            return Result.Ok<List<User>>(success);
        }
        catch (Exception ex)
        {
            return Result.Exception<List<User>>("Failed to get all users");
        }
    }

}

