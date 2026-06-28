using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni2.Models;



namespace Uni2.ClassMapping
{
    internal class CoursesConfiguration : IEntityTypeConfiguration<Courses>
    {
        public void Configure(EntityTypeBuilder<Courses> builder)
        {
            builder.ToTable("Courses");

           
            builder.HasKey(c => c.CourseId);

            
            builder.Property(c => c.CourseName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.StartDate)
                .IsRequired();

            builder.Property(c => c.EndDate)
                .IsRequired();

            builder.HasOne(c => c.Teacher)
                .WithMany(u => u.CoursesTaught)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
