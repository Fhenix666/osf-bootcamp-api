using BootCamp.Adm.Data.ConfigEntity;
using BootCamp.Adm.Entities;
using Microsoft.EntityFrameworkCore;

namespace BootCamp.Adm.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        #region === [ ENTITIES ] ===
       
        public virtual DbSet<User> User { get; set; }
        //public virtual DbSet<UserStatus> UserStatus { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserConfig.Config(modelBuilder.Entity<User>());


        }
    }
}
