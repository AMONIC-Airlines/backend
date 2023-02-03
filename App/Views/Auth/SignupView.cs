using System.ComponentModel.DataAnnotations;

namespace App.Views.Auth;

public class SignupView
{
    [Required]
    [EmailAddress]
    [MaxLength(150)]
    public string? Email { get; set; }

    [Required]
    [MaxLength(50)]
    public string? FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string? LastName { get; set; }

    [Required]
    [MaxLength(16)]
    [MinLength(8)]
    public string? Password { get; set; }

    [Required]
    public DateOnly? Birthdate { get; set; }
}
