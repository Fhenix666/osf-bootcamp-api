using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BootCamp.Adm.ViewModels
{
    /// <summary>
    /// BaseViewModel
    /// </summary>
    public class BaseViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        public Nullable<DateTime> UpdatedAt { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="StatusType"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool Active { get; set; }
    }
}
