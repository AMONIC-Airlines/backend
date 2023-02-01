using Domain.Logic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Role
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Title { get; set; }

    public Result IsValid()
    {
        if (Id <= 0)
        {
            return Result.Fail("Id is Invalid.");
        }

        if (string.IsNullOrEmpty(Title))
        {
            return Result.Fail("Null or empty Title.");
        }

        if (Title?.Length > 50)
        {
            return Result.Fail("MaxLength of Title is 50.");
        }

        return Result.Ok();
    }
}
