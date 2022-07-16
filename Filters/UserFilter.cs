using BootCamp.Adm.Commons;
using BootCamp.Adm.Filters.IFilters;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BootCamp.Adm.Filters
{
    /// <summary>
    /// UserFilter
    /// </summary>
    /// <seealso cref="BootCamp.Adm.Filters.IFilters.IFilter" />
    public class UserFilter : IFilter
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        public string Phone { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string BusinessEmail { get; set; }
        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        public Nullable<bool> Active { get; set; } = Constants.Active;
        /// <summary>
        /// Filters the name of the by.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public IQueryable FilterByName(IQueryable query)
        {
            return query.Where("Name.ToUpper().Contains(@0)", this.Name.ToUpper());
        }
        /// <summary>
        /// Filters the by email.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public IQueryable FilterByBusinessEmail(IQueryable query)
        {
            return query.Where("BusinessEmail.ToUpper().Contains(@0)", this.BusinessEmail.ToUpper());
        }
        /// <summary>
        /// Filters the by phone.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public IQueryable FilterByPhone(IQueryable query)
        {
            return query.Where("Phone.ToUpper().Contains(@0)", this.Phone.ToUpper());
        }
    }
}
