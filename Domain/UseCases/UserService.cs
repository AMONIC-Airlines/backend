﻿using Domain.Logic;
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
        if (id <= 0)
        {
            return Result.Fail<User>("UserService.GetUser: Invalid id.");
        }

        try
        {
            var success = await _db.Get(id);

            if (success is null)
            {
                return Result.Fail<User>("UserService.GetUser: User doesn't exist.");
            }

            return Result.Ok<User>(success);
        }
        catch (Exception ex)
        {
            return Result.Fail<User>("UserService.GetUser: " + ex.Message);
        }

    }

    public async Task<Result<User>> Registration(User user)
    {
        if (user.IsValid().IsFailure)
        {
            return Result.Fail<User>("UserService.Registration: " + user.IsValid().Error);
        }

        try
        { 
            var item = await _db.GetByEmail(user.Email!);

            if (item is not null)
            {
                return Result.Fail<User>("UserService.Registration: Email is already taken.");
            }

            user.Password = User.GeneratePassword(user.Password!);

            var success = await _db.Create(user);

            return Result.Ok<User>(success);
        }
        catch (Exception ex)
        {
            return Result.Fail<User>("UserService.Registration: " + ex.Message);
        }
    }

    public async Task<Result<User>> Authorization(string email, string password)
    {
        if (string.IsNullOrEmpty(email))
        {
            return Result.Fail<User>("UserService.Authorization: Null or empty Email.");
        }

        if (string.IsNullOrEmpty(password))
        {
            return Result.Fail<User>("UserService.Authorization: Null or empty Password.");
        }

        try
        {
            var success = await _db.GetByEmail(email);

            if (success is null)
            {
                return Result.Fail<User>("UserService.Authorization: User doesn't exist.");
            }

            var generatedPassword = User.GeneratePassword(password);

            if (success.Password != generatedPassword)
            {
                return Result.Fail<User>("UserService.Authorization: Wrong Password.");
            }

            return Result.Ok<User>(success);
        }
        catch (Exception ex)
        {
            return Result.Fail<User>("UserService.Authorization: " + ex.Message);
        }
    }

    public async Task<Result<User>> UpdateUser(User user)
    {
        if (user.IsValid().IsFailure)
        {
            return Result.Fail<User>("UserService.UpdateUser: " + user.IsValid().Error);
        }

        try
        {
            var success = await _db.Update(user);

            return Result.Ok<User>(success);
        }
        catch (Exception ex)
        {
            return Result.Fail<User>("UserService.UpdateUser: " + ex.Message);
        }
    }

    public async Task<Result<User>> DeleteUser(int id)
    {
        if (id <= 0)
        {
            return Result.Fail<User>("UserService.DeleteUser: Invalid id.");
        }

        try
        {
            var success = await _db.Delete(id);

            return Result.Ok<User>(success);  
        }
        catch (Exception ex)
        {
            return Result.Fail<User>("UserService.DeleteUser: " + ex.Message);
        }
    }

    public async Task<Result<User>> ActivateUser(int id)
    {
        if (id <= 0)
        {
            return Result.Fail<User>("UserService.ActivateUser: Invalid id.");
        }

        try
        {
            var success = await _db.Get(id);

            if (success is null)
            {
                return Result.Fail<User>("UserService.ActivateUser: User doesn't exist.");
            }

            success.Active = true;

            var updated = await _db.Update(success!);

            return Result.Ok<User>(updated);
        }
        catch (Exception ex)
        {
            return Result.Fail<User>("UserService.ActivateUser: " + ex.Message);
        }
    }

    public async Task<Result<User>> DeactivateUser(int id)
    {
        if (id <= 0)
        {
            return Result.Fail<User>("UserService.DeactivateUser: Invalid id.");
        }

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
            return Result.Fail<User>("UserService.DeactivateUser: " + ex.Message);
        }
    }

    public async Task<Result<User>> ChangeRole(int id, int roleId)
    {
        if (id <= 0)
        {
            return Result.Fail<User>("UserService.ChangeRole: Invalid id.");
        }

        if (roleId <= 0)
        {
            return Result.Fail<User>("UserService.ChangeRole: Invalid roleId.");
        }

        try
        {
            var success = await _db.Get(id);

            if (success is null)
            {
                return Result.Fail<User>("UserService.ChangeRole: User doesn't exist.");
            }

            success.RoleId= roleId;

            var updated = await _db.Update(success!);

            return Result.Ok<User>(updated);
        }
        catch (Exception ex)
        {
            return Result.Fail<User>("UserService.ChangeRole: " + ex.Message);
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
            return Result.Fail<List<User>>("UserService.GetAllUsers: " + ex.Message);
        }
    }

}

