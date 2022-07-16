using BootCamp.Adm.Data;
using BootCamp.Adm.Entities;
using BootCamp.Adm.Repository.Interfaces;

namespace BootCamp.Adm.Repository
{
    /// <summary>
    /// UserStatusRepository
    /// </summary>
    /// <seealso cref="BootCamp.Adm.Repository.BaseRepository{BootCamp.Adm.Entities.UserStatus}" />
    /// <seealso cref="BootCamp.Adm.Repository.Interfaces.IUserStatusRepository" />
    public class UserStatusRepository : BaseRepository<UserStatus>, IUserStatusRepository
    {
        private readonly DBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserStatusRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserStatusRepository(DBContext context) : base(context)
        {
            _context = context;
        }
    }
}
