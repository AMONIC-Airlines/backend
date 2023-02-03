namespace App.Views.Auth;

public class AuthUserView
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateOnly? Birthdate { get; set; }
    public string? Token { get; set; }
}
