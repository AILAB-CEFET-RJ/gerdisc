using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace gerdisc.Propierties
{
    public class SingingConfiguration : ISingingConfiguration
    {
        public RsaSecurityKey Key { get; set; }
        public SingingConfiguration(string key)
        {
            using( var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.FromXmlString(key);
                this.Key = new RsaSecurityKey(rsa.ExportParameters(true));
            }
        }
    }
}