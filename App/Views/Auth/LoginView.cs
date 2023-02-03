using System.ComponentModel.DataAnnotations;

namespace App.Views.Auth;

public class LoginView
{
    [Required]
    [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
    [MaxLength(150)]
    public string? Email { get; set; }

    [Required]
    [MaxLength(16)]
    [MinLength(8)]
    public string? Password { get; set; }
}
