using System.Text.RegularExpressions;

namespace Domain.Logic;
public class RegexValidation
{
    public static bool PhoneIsValid(string Phone)
    {
        Regex validatePhoneNumberRegex = new("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");
        return validatePhoneNumberRegex.IsMatch(Phone);
    }

    public static bool PhoneIsNotValid(string Phone)
    {
        return !PhoneIsValid(Phone);
    }

    public static bool EmailIsValid(string Email)
    {
        Regex validateEmailRegex = new ("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
        return validateEmailRegex.IsMatch(Email);
    }

    public static bool EmailIsNotValid(string Email)
    {
        return !EmailIsValid(Email);
    }

    public static bool PasswordIsStrong(string Password)
    {
        Regex validateGuidRegex = new("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
        return validateGuidRegex.IsMatch(Password);
    }

    public static bool PasswordIsNotStrong(string Password)
    {
        return !PasswordIsStrong(Password);
    }

    public static bool DateIsValid(string Date)
    {
        Regex validateDateRegex = new Regex("^[0-9]{1,2}\\.[0-9]{1,2}\\.[0-9]{4}$");
        return validateDateRegex.IsMatch(Date);
    }

    public static bool DateIsNotValid(string Date)
    {
        return !DateIsValid(Date);
    }
}
