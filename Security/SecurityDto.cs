
namespace BootCamp.Adm.Security
{
    /// <summary>
    /// SecurityDto
    /// </summary>
    public class SecurityDto
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }
        /// <summary>
        /// Gets or sets the security configuration.
        /// </summary>
        /// <value>
        /// The security configuration.
        /// </value>
        public SecurityInfo SecurityConfig { get; set; }
    }
}
