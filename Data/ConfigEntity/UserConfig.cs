using BootCamp.Adm.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootCamp.Adm.Data.ConfigEntity
{
    public static class UserConfig
    {
        public static void Config(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id);

            entity.Property(e => e.Name).IsRequired().HasMaxLength(350);
            entity.Property(e => e.Lastname).IsRequired(false).HasMaxLength(100);
            entity.Property(e => e.MotherLastname).IsRequired(false).HasMaxLength(100);
            entity.Property(e => e.Username).IsRequired().HasMaxLength(250);
            entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(250);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(250);
            entity.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);


            entity.HasData( new User { Id = 1, CreatedAt = new System.DateTime(2022,07,16), Name = "System", Lastname = "System", Username ="System", PasswordHash = "", Email = "System@BootCamp.com"} );
            entity.HasData( new User { Id = 2, CreatedAt = new System.DateTime(2022, 07, 16), Name = "Fermin", Lastname = "Angeles", Username ="Escalona", PasswordHash = "", Email = "Ing.Angeles.Escalona@BootCamp.com"} );

        }
    }
}
