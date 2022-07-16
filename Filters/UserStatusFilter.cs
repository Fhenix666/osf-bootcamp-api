using BootCamp.Adm.Commons;
using BootCamp.Adm.Filters.IFilters;
using System;

namespace BootCamp.Adm.Filters
{
    /// <summary>
    /// UserStatusFilter
    /// </summary>
    /// <seealso cref="BootCamp.Adm.Filters.IFilters.IFilter" />
    public class UserStatusFilter : IFilter
    {
        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        public Nullable<bool> Active { get; set; } = Constants.Active;
    }
}
