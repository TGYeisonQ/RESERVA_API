namespace Application.Common.Security;

public static class HashValue
{
    public static string Hashing(string s) => BCrypt.Net.BCrypt.EnhancedHashPassword(s, 13);
}
