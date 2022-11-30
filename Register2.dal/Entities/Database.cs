using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Register2.dal.Entities
{
    public partial class Database : DbContext
    {
        public Database()
            : base("name=Database")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<BasicSetting> BasicSettings { get; set; }
        public virtual DbSet<BlockedIP> BlockedIPs { get; set; }
        public virtual DbSet<EntityProfile> EntityProfiles { get; set; }
        public virtual DbSet<EntityProfileItem> EntityProfileItems { get; set; }
        public virtual DbSet<Forum> Fora { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<BlockedIP>()
                .Property(e => e.IPAddress)
                .IsUnicode(false);

            modelBuilder.Entity<EntityProfile>()
                .HasMany(e => e.EntityProfileItems)
                .WithOptional(e => e.EntityProfile)
                .HasForeignKey(e => e.EntityProfile_ID);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstNameEn)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastNameEn)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Fax)
                .IsUnicode(false);
        }
    }
}
