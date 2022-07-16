using BootCamp.Adm.Dto;
using BootCamp.Adm.ViewModels;
using BootCamp.Adm.ViewModels.Output;
using System.Collections.Generic;

namespace BootCamp.Adm.Security
{
    /// <summary>
    /// SecurityInfo
    /// </summary>
    public class SecurityInfo
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public OutputUserViewModel User { get; set; }
        /// <summary>
        /// Gets or sets the profile list.
        /// </summary>
        /// <value>
        /// The profile list.
        /// </value>
        public List<CatalogSimple> ProfileList { get; set; } = new List<CatalogSimple>();
        
    }
}
