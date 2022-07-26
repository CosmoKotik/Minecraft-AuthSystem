using System.Security.Cryptography;
using System.Text;

namespace EnderAuth.Core
{
    public class Encryption
    {
        public static string HashPassword(string rawPassword)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] rawBytes = Encoding.ASCII.GetBytes(rawPassword);
                byte[] hashBytes = md5.ComputeHash(rawBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }
    }
}
