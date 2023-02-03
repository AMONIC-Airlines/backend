using System.Security.Cryptography;
using System.Text;

namespace Domain.Logic;

public class PasswordGenerator
{
    public static string GeneratePassword(string password)
    {
        using MD5 md5 = MD5.Create();

        md5.ComputeHash(Encoding.ASCII.GetBytes(password));
        byte[] result = md5.Hash!;

        for (int i = 0; i < 256; ++i)
        {
            md5.ComputeHash(result!);
            result = md5.Hash!;
        }

        StringBuilder strBuilder = new StringBuilder();
        for (int i = 0; i < result.Length; i++)
        {
            strBuilder.Append(result[i].ToString("x2"));
        }

        return strBuilder.ToString();
    }
}
