using System.ComponentModel.DataAnnotations;

namespace App.Views.Auth;

public class LoginView
{
    [Required]
    [EmailAddress]
    [MaxLength(150)]
    public string? Email { get; set; }

    [Required]
    [MaxLength(16)]
    [MinLength(8)]
    public string? Password { get; set; }
}
