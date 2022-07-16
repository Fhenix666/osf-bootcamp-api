using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.Adm.Entities
{
    /// <summary>
    /// UserStatus
    /// </summary>
    public class UserStatus : EntityBaseId
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [MaxLength(150)]
        public string Name { get; set; }
    }
}
