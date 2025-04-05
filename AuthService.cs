using Bakery;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public class AuthService
{
    private readonly ПекарняEntities _context;

    public AuthService()
    {
        _context = new ПекарняEntities();
    }

    public Пользователи Authenticate(string username, string password)
    {
        var user = _context.Пользователи.FirstOrDefault(u => u.Логин == username);
        if (user == null)
        {
            return null; // Пользователь не найден
        }

        // Хэшируем введённый пароль и сравниваем с хранимым хэшем
        string hashedPassword = ComputeSha256Hash(password);
        return user.Пароль_Хэш == hashedPassword ? user : null;
    }

    public string ComputeSha256Hash(string rawData)
    {
        using SHA256 sha256Hash = SHA256.Create();
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
        var builder = new StringBuilder();
        foreach (byte b in bytes)
        {
            builder.Append(b.ToString("x2"));
        }
        return builder.ToString();
    }
}
