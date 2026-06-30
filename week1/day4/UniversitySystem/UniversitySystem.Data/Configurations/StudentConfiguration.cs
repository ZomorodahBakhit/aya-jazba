using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Data.Entities;

namespace UniversitySystem.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(student => student.Id);

            builder.Property(student => student.Id)
                .ValueGeneratedOnAdd();

            builder.Property(student => student.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(student => student.Email)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
