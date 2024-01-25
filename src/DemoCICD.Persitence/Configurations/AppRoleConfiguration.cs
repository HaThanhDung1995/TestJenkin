﻿using DemoCICD.Domain.Entities.Identity;
using DemoCICD.Persitence.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCICD.Persitence.Configurations
{
    internal sealed class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable(TableNames.AppRoles);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .HasMaxLength(250).IsRequired(true);
            builder.Property(x => x.RoleCode).HasMaxLength(50).IsRequired(true);

            // Each User can have many RoleClaims
            builder.HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(uc => uc.RoleId)
                .IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany(e => e.UserRoles)
                .WithOne()
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            // Each User can have many Permission
            builder.HasMany(e => e.Permissions)
                .WithOne()
                .HasForeignKey(p => p.RoleId)
                .IsRequired();
        }
    }
}
