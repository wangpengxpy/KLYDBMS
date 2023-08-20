using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace KLYDBMS.Utilities
{
    public static class KLYAlgorithm
    {
        private static readonly byte[] AesSaltBytes = new byte[16] { 9, 216, 4, 9, 145, 169, 201, 13, 34, 27, 67, 189, 255, 104, 219, 122 };
        public static string SHA512Encrypt(string plainText)
        {
            var sb = new StringBuilder();
            var bytes = Encoding.UTF8.GetBytes(plainText);
            var sha512 = SHA512.Create();
            var hashes = sha512.ComputeHash(bytes);
            for (int i = 0; i < hashes.Length; i++)
            {
                sb.Append(hashes[i].ToString("x2"));
            }

            return sb.ToString();
        }

        public static string AESEncrypt(string plainText, string key)
        {
            var encryptKey = Encoding.UTF8.GetBytes(key);

            using var aesAlg = Aes.Create();
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.IV = AesSaltBytes;
            using var encryptor = aesAlg.CreateEncryptor(encryptKey, aesAlg.IV);
            using var msEncrypt = new MemoryStream();
            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor,
                CryptoStreamMode.Write))

            using (var swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(plainText);
            }

            var encrypted = msEncrypt.ToArray();

            return Convert.ToBase64String(encrypted);
        }

        public static string AESDecrypt(string plainText, string key)
        {
            var cipherText = Convert.FromBase64String(plainText);

            var decryptKey = Encoding.UTF8.GetBytes(key);

            using var aesAlg = Aes.Create();
            aesAlg.Mode = CipherMode.CBC;
            using var decryptor = aesAlg.CreateDecryptor(decryptKey, AesSaltBytes);
            string result;
            using (var msDecrypt = new MemoryStream(cipherText))
            {
                using var csDecrypt = new CryptoStream(msDecrypt,
                    decryptor, CryptoStreamMode.Read);
                using var srDecrypt = new StreamReader(csDecrypt);
                result = srDecrypt.ReadToEnd();
            }

            return result;
        }
    }
}
