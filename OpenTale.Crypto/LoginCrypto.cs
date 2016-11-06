using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OpenTale.Crypto
{
    public static class LoginCrypto
    {
        public static byte[] Encrypt(string str)
        {
            byte[] encrypted_string = new byte[str.Length + 1];

            for (int i = 0; i < str.Length; i++)
            {
                encrypted_string[i] = (byte)Convert.ToChar((((byte)str[i]) ^ 195) + 15);
            }
            encrypted_string[str.Length] = (byte)Convert.ToChar(216);
            return encrypted_string;
        }

        public static string LoginDecrypt(byte[] tmp, int size)
        {
            byte[] bytes = new byte[size - 1];
            for (int i = 0; i < (size - 1); i++)
            {
                bytes[i] = (byte)(tmp[i] - 15);
            }

            return Encoding.ASCII.GetString(bytes);
        }

        public static string CreateLoginVersion(string version)
        {
            Random r = new Random();
            string output = "00";
            output += r.Next(0, 126).ToString("X2");
            output += r.Next(0, 126).ToString("X2");
            output += r.Next(0, 126).ToString("X2");
            output += (char)11;
            output += version;
            return output;
        }

        public static string CreateLoginHash(string dxHash, string glHash, string userName)
        {
            string output = "";
            output += dxHash;
            output += glHash;
            output += userName;
            return GetMD5Hash(output);
        }

        public static string CreatePasswordHash(string password)
        {
            return BitConverter.ToString(new SHA512CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(password))).Replace("-", String.Empty).ToUpper();

        }

        private static string GetMD5Hash(string textToHash)
        {
            if (string.IsNullOrEmpty(textToHash))
            {
                return string.Empty;
            }

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] by_textToHash = Encoding.Default.GetBytes(textToHash);
            byte[] result = md5.ComputeHash(by_textToHash);

            return System.BitConverter.ToString(result).Replace("-", "");
        }
    }
}
