using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni2.Models;

namespace Uni2.ClassMapping
{
    internal class UsersConfiguration: IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.UserId);

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(u => u.EmailAddress)
                .IsRequired()
                .HasMaxLength(128);

            builder.HasIndex(u => u.EmailAddress)
                .IsUnique();

            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(16);

            builder.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(32);
        }
    }
}
