using Microsoft.IdentityModel.Tokens;

namespace gerdisc.Properties
{
    /// <summary>
    /// Represents the signing configuration for generating tokens.
    /// </summary>
    public interface ISigningConfiguration
    {
        /// <summary>
        /// Gets the RSA security key used for signing.
        /// </summary>
        RsaSecurityKey Key { get; }
    }
}
