using Microsoft.IdentityModel.Tokens;

namespace gerdisc.Properties
{
    public interface ISingingConfiguration
    {
        public RsaSecurityKey Key { get; set; }
    }
}