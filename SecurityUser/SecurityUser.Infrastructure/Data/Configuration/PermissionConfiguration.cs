using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecurityUser.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityUser.Infrastructure.Data.Configuration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {

            builder.HasKey(e => e.IdPermission);

            builder.Property(e => e.PermissionType)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

        }
    }
}
