using System.Security.Cryptography;
using System.Text;

namespace JWTExample.Hash
{
    public class Hash512
    {
        public static string ComputeHash512(string password)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);

                byte[] hashBytes = sha512.ComputeHash(inputBytes);

                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }
    }
}
