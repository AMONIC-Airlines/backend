﻿using Domain.Logic;
using Database.Interfaces;
using Database.Models;

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
            return Result.Exception<User>();
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

            user.Password = PasswordGenerator.GeneratePassword(user.Password!);

            var success = await _db.Create(user);

            return Result.Ok<User>(success);
        }
        catch (Exception)
        {
            return Result.Exception<User>();
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

            var generatedPassword = PasswordGenerator.GeneratePassword(password);

            if (success.Password != generatedPassword)
            {
                return Result.Fail<User>("Wrong Password.");
            }

            return Result.Ok<User>(success);
        }
        catch (Exception)
        {
            return Result.Exception<User>();
        }
    }

    public async Task<Result<User>> UpdateUser(User user)
    {
        try
        {
            var success = await _db.Update(user);

            return Result.Ok<User>(success);
        }
        catch (Exception)
        {
            return Result.Exception<User>();
        }
    }

    public async Task<Result<User>> DeleteUser(int id)
    {
        try
        {
            var success = await _db.Delete(id);

            return Result.Ok<User>(success);
        }
        catch (Exception)
        {
            return Result.Exception<User>();
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
        catch (Exception)
        {
            return Result.Exception<User>();
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
        catch (Exception)
        {
            return Result.Exception<User>();
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

            success.RoleId = roleId;

            var updated = await _db.Update(success!);

            return Result.Ok<User>(updated);
        }
        catch (Exception)
        {
            return Result.Exception<User>();
        }
    }

    public async Task<Result<List<User>>> GetAllUsers()
    {
        try
        {
            var success = await _db.GetAll();

            return Result.Ok<List<User>>(success);
        }
        catch (Exception)
        {
            return Result.Exception<List<User>>();
        }
    }
}
