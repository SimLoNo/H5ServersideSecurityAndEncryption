using System.Security.Cryptography;
using System.Text;

namespace H5ServersideMonday.Components.Security
{
    public class Encrypter
    {
        public static string Encrypt(string textToEncrypt, string publicKey)
        {
            using (RSACryptoServiceProvider rsa = new())
            {
                rsa.FromXmlString(publicKey);

                byte[] byteArrayToEncrypt = Encoding.UTF8.GetBytes(textToEncrypt);
                var encryptedData = rsa.Encrypt(byteArrayToEncrypt,true);
                return Convert.ToBase64String(encryptedData);
            }
        }
    }
}
