using System.ComponentModel.DataAnnotations;

namespace App.Views.User;

public class UpdateView
{
    [Required]
    [MaxLength(50)]
    public string? FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string? LastName { get; set; }

    [Required]
    public DateOnly? Birthdate { get; set; }
}
