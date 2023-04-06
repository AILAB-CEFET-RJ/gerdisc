using Microsoft.IdentityModel.Tokens;

namespace gerdisc.Properties
{
    public interface ISigningConfiguration
    {
        public RsaSecurityKey Key { get; set; }
    }
}