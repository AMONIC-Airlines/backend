using Domain.Logic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    public int Id { get; set; }

    [Required]
    public int OfficeId { get; set; }

    [Required]
    public int RoleId { get; set; }

    [Required]
    [MaxLength(254)]
    public string? Email { get; set; }

    [Required]
    [MaxLength(64)]
    public string? Password { get; set; }

    [Required]
    [MaxLength(50)]
    public string? FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string? LastName { get; set;}

    [Required]
    public DateOnly Birthdate { get; set; }

    [Required]
    public bool Active { get; set; }

    public Result IsValid()
    {
        if (Id <= 0)
        {
            return Result.Fail("Users.IsValid: Id is Invalid.");
        }

        if (OfficeId <= 0)
        {
            return Result.Fail("Users.IsValid: OfficeId is Invalid.");
        }

        if (RoleId <= 0)
        {
            return Result.Fail("Users.IsValid: RoleId is Invalid.");
        }

        if (string.IsNullOrEmpty(Email))
        {
            return Result.Fail("Users.IsValid: Null or empty Email.");
        }

        if (RegexValidation.EmailIsNotValid(Email))
        {
            return Result.Fail("Users.IsValid: Email is Invalid.");
        }

        if (string.IsNullOrEmpty(Password))
        {
            return Result.Fail("Users.IsValid: Null or empty Password.");
        }

        if (RegexValidation.PasswordIsNotStrong(Password))
        {
            return Result.Fail("Users.IsValid: Password is not strong enough.");
        }

        if (Password?.Length > 64)
        {
            return Result.Fail("User.IsValid: MaxLength of Password is 64.");
        }

        if (string.IsNullOrEmpty(FirstName))
        {
            return Result.Fail("Users.IsValid: Null or empty FirstName.");
        }

        if (FirstName?.Length > 50)
        {
            return Result.Fail("User.IsValid: MaxLength of FirstName is 50.");
        }

        if (string.IsNullOrEmpty(LastName))
        {
            return Result.Fail("Users.IsValid: Null or empty LastName.");
        }

        if (LastName?.Length > 50)
        {
            return Result.Fail("User.IsValid: MaxLength of LastName is 50.");
        }

        if (RegexValidation.DateIsNotValid(Birthdate.ToString()) || Birthdate <= DateOnly.Parse(DateTime.UtcNow.ToString("d")))
        {
            return Result.Fail("User.IsValid: Date is invalid.");
        }

        return Result.Ok();
    }

    public static string GenerateSalt()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(128 / 8));
    }

    public static string GeneratePassword(string password)
    {
        MD5 md5 = new MD5CryptoServiceProvider();  
        md5.ComputeHash(Encoding.ASCII.GetBytes(password));

        byte[] result = md5.Hash;

        StringBuilder strBuilder = new StringBuilder();
        for (int i = 0; i < result.Length; i++)
        {
            strBuilder.Append(result[i].ToString("x2"));
        }

        return strBuilder.ToString();
    }

}
