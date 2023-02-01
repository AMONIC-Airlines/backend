using Domain.Logic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domain.Models;

public class Office
{
    public int Id { get; set; }

    [Required]
    public int CountryId { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Title { get; set; }

    [Required]
    [MaxLength(15)]
    public string? Phone { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Contact { get; set; }

    public Result IsValid()
    {
        if (Id <= 0)
        {
            return Result.Fail("Id is Invalid.");
        }

        if (CountryId <= 0)
        {
            return Result.Fail("CountryId is Invalid.");
        }

        if (string.IsNullOrEmpty(Title))
        {
            return Result.Fail("Null or empty Title.");
        }

        if (Title?.Length > 50)
        {
            return Result.Fail("MaxLength of Title is 50.");
        }

        if (string.IsNullOrEmpty(Phone))
        {
            return Result.Fail("Null or empty Phone.");
        }

        if(RegexValidation.PhoneIsNotValid(Phone))
        {
            return Result.Fail("Phone is Invalid.");
        }

        if(string.IsNullOrEmpty(Contact))
        {
            return Result.Fail("Null or empty Contact.");
        }

        if (Contact?.Length > 50)
        {
            return Result.Fail("MaxLength of Contact is 50.");
        }

        return Result.Ok();
    }
}
