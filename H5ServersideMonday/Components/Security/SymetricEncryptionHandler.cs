using Microsoft.AspNetCore.DataProtection;

namespace H5ServersideMonday.Components.Security
{
    public class SymetricEncryptionHandler
    {
        private readonly IDataProtector _protector;
        public SymetricEncryptionHandler(IDataProtectionProvider protector)
        {
            _protector = protector.CreateProtector("EncryptionKey");
        
        }

        public string EncryptData(string textToEncrypt)
        {
            return _protector.Protect(textToEncrypt);
        }

        public string DecryptData(string textToDecrypt)
        {
            return _protector.Unprotect(textToDecrypt);
        }
    }
}
