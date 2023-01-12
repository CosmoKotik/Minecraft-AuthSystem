using Newtonsoft.Json;
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

        public static string Base64Encode(object obj)
        {
            string json = "";
            
            if (!obj.GetType().IsGenericType)
                json = JsonConvert.SerializeObject(obj);
            else json = obj.ToString();

            var jsonBytes = System.Text.Encoding.UTF8.GetBytes(json);
            return System.Convert.ToBase64String(jsonBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
