using System.Security.Cryptography;
using System.Text;

namespace H5ServersideMonday.Components.Security
{
    public class AsymetricEncryptionHandler
    {
        private string _privateKey;
        private string _publicKey;

        private string _privatePath = "privateKey.pem";
        private string _publicPath = "publicKey.pem";
        public AsymetricEncryptionHandler()
        {
            ;
            if (!File.Exists(_privatePath)|| !File.Exists(_publicPath)) 
            {
                using (RSACryptoServiceProvider rsa = new()) 
                {
                    _privateKey = rsa.ToXmlString(true);
                    _publicKey = rsa.ToXmlString(false);

                    File.WriteAllText(_privatePath, _privateKey);
                    File.WriteAllText(_publicPath, _publicKey);
                }
            }
            else
            {
                _privateKey = File.ReadAllText(_privatePath);
                _publicKey = File.ReadAllText(_publicPath);
            }

            
        }

        public string EncryptAsymetric(string textToEncrypt)
        {
            return Encrypter.Encrypt(textToEncrypt, _publicKey);
        }

        public string DecryptAssymetric(string textToDecrypt)
        {
            using (RSACryptoServiceProvider rsa = new())
            {
                rsa.FromXmlString(_privateKey);

                byte[] byteArrayToDecrypt = Convert.FromBase64String(textToDecrypt);
                var decryptedText = rsa.Decrypt(byteArrayToDecrypt, true);
                return Encoding.UTF8.GetString(decryptedText);

            }
        }
    }
}
