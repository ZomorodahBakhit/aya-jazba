using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni2.Models;


namespace Uni2.ClassMapping
{
    internal class GradesConfiguration : IEntityTypeConfiguration<Grades>
    {
        public void Configure(EntityTypeBuilder<Grades> builder)
        {
            builder.ToTable("Grades");

            
            builder.HasKey(g => g.GradeId);

            
            builder.Property(g => g.Score)
                .IsRequired()
                .HasPrecision(5, 2);

            
            builder.HasIndex(g => new { g.StudentId, g.AssignmentId })
                .IsUnique();

            builder.HasOne(g => g.Assignment)
                .WithMany(a => a.Grades)
                .HasForeignKey(g => g.AssignmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(g => g.Student)
                .WithMany(u => u.Grades)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    
    }
