using BCrypt.Net;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SkiaSharp;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace H5ServersideMonday.Components.Security
{
    public class Hashing
    {
        private string Salt = "aÆDSFGJNGWÅJFNBJkddfgbåUJRNBDSFBIVKNF";
        public dynamic HashSha256(dynamic returnType, string password)
        {
            byte[] hashedByteArray;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                hashedByteArray = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Salt + password));

            }
            string hashedString = Convert.ToBase64String(hashedByteArray);
            if (returnType is string) 
            {
                return hashedString;
            }
            else if (returnType is byte[])
            {
                return Encoding.UTF8.GetBytes(hashedString);
            }

            return null;
        }

        public dynamic HashHmac256(dynamic returnType, byte[] key, string input)
        {
            byte[] hashValue;
            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                byte[] inputArray = Encoding.UTF8.GetBytes(input);
                hashValue = hmac.ComputeHash(inputArray);
            }
            string hashedString = Convert.ToBase64String(hashValue);
            if (returnType is string)
            {
                return hashedString;
            }
            else if (returnType is byte[])
            {
                return Encoding.UTF8.GetBytes(hashedString);
            }
            return null;
        }

        public dynamic HashPbkdf2(dynamic returnType, string input, int iterationCount)
        {
            byte[] hashedByteArray;
            byte[] byteArraySalt = Encoding.UTF8.GetBytes(Salt);

            hashedByteArray = KeyDerivation.Pbkdf2(input, byteArraySalt, KeyDerivationPrf.HMACSHA256, iterationCount, 256 / 8);
            string hashedString = Convert.ToBase64String(hashedByteArray);

            if (returnType == typeof(string))
            {
                return hashedString;
            }
            else if (returnType == typeof(byte[]))
            {
                return Encoding.UTF8.GetBytes(hashedString);
            };
            return null;
        }

        public dynamic HashBCrypt(dynamic returnType, string input)
        {
            string hashingResult = BCrypt.Net.BCrypt.HashPassword(input, Salt);

            if (returnType is string)
            {
                return hashingResult;
            }
            else if (returnType is byte[])
            {
                return Encoding.UTF8.GetBytes(hashingResult);
            }
            return null;
        }

        public bool BCryptVerifyHashing(string textToHash, string hashedValue)
        {
            return BCrypt.Net.BCrypt.Verify(textToHash, hashedValue);
        }
    }
}
