using Microsoft.IdentityModel.Tokens;

namespace gerdisc.Propierties
{
    public interface ISingingConfiguration
    {
        public RsaSecurityKey Key { get; set; }
    }
}