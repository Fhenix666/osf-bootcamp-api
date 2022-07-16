using BootCamp.Adm.Security;
using BootCamp.Adm.ViewModels.Input;
using System.Threading.Tasks;

namespace BootCamp.Adm.Manager.Interfaces
{
    /// <summary>
    /// ISecurityManager
    /// </summary>
    public interface ISecurityManager 
    {
        /// <summary>
        /// Gets the security information.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns></returns>
        Task<SecurityInfo> GetSecurityInfo(InputCredentialsViewModel credentials);
        /// <summary>
        /// Gets the security mobile information.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns></returns>
        Task<SecurityInfo> GetSecurityMobileInfo(InputCredentialsViewModel credentials);
        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns></returns>
        Task<string> GetToken(InputCredentialsViewModel credentials);
    }
}
