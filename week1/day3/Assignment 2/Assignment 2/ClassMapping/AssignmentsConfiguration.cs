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
    internal class AssignmentConfiguration : IEntityTypeConfiguration<Assignments>
    {
        public void Configure(EntityTypeBuilder<Assignments> builder)
        {

            builder.ToTable("Assignments");

            
            builder.HasKey(a => a.AssignmentId);

          
            builder.Property(a => a.AssignmentTitle)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(a => a.Description)
                    .HasColumnType("nvarchar(max)");

            builder.Property(a => a.Weight)
                    .IsRequired()
                    .HasPrecision(5, 2);

            builder.Property(a => a.MaxGrade)
                    .IsRequired();

            builder.Property(a => a.DueDate)
                    .IsRequired();

            builder.HasOne(a => a.Course)
                    .WithMany(c => c.Assignments)
                    .HasForeignKey(a => a.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
