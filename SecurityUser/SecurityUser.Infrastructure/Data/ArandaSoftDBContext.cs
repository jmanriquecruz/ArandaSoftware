using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SecurityUser.Core.Entities;
using SecurityUser.Infrastructure.Data.Configuration;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SecurityUser.Infrastructure.Data
{
    public partial class ArandaSoftDBContext : DbContext
    {
        public ArandaSoftDBContext()
        {
        }

        public ArandaSoftDBContext(DbContextOptions<ArandaSoftDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());

            // OnModelCreatingPartial(modelBuilder);
        }

       // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
