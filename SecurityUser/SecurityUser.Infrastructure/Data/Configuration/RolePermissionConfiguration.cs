using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecurityUser.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityUser.Infrastructure.Data.Configuration
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(e => new { e.IdRole, e.IdPermission });

            builder.ToTable("Role_Permission");

            builder.HasOne(d => d.IdPermissionNavigation)
                .WithMany(p => p.RolePermission)
                .HasForeignKey(d => d.IdPermission)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permission_P");

        /*    builder.HasOne(d => d.IdRoleNavigation)
                .WithMany(p => p.RolePermission)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Role_Permision");*/

        }
    }
}
