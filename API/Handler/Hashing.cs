using BC = BCrypt.Net.BCrypt;

namespace API.Handler
{
    public class Hashing
    {
        private static string GetRandomSalt()
        {
            return BC.GenerateSalt(12);
        }

        public static string HashPassword(string password)
        {
            return BC.HashPassword(password, GetRandomSalt());
        }

        public static bool ValidatePassword(string password, string correctHash)
        {
            return BC.Verify(password, correctHash);
        }
    }
}
