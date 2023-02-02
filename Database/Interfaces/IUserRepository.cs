using Domain.Models;

namespace Database.Interfaces;

public interface IUserRepository : IBaseRepository<User> 
{
    Task<User?> GetByOfficeId(int OfficeId);

    Task<User?> GetByRoleId(int RoleId);

    Task<User?> GetByEmail(string Email);

    Task<User?> GetByFirstName(string FirstName);

    Task<User?> GetByLastName(string LastName);

    Task<User?> GetByBirthdate(DateOnly Birthdate);

    Task<User?> GetByActive(bool Active);

    Task<User?> GetByPassword(string Password);

 }
