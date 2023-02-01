using Domain.Logic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Country
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string? Name { get; set; }

    public Result IsValid()
    {
        if (Id <= 0)
        {
            return Result.Fail("Countries.IsValid: Id is Invalid.");
        }

        if (string.IsNullOrEmpty(Name))
        {
            return Result.Fail("Countries.IsValid: Null or empty Name.");
        }

        if (Name?.Length > 50)
        {
            return Result.Fail("Countries.IsValid: MaxLength of Name is 50.");
        }

        return Result.Ok();
    }
}
