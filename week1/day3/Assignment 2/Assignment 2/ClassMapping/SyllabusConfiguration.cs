using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni2.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;



namespace Uni2.ClassMapping
{
    internal class SyllabusConfiguration : IEntityTypeConfiguration<Syllabus>
    {
        public void Configure(EntityTypeBuilder<Syllabus> builder)
        {
            builder.ToTable("Syllabuses");

            
            builder.HasKey(s => s.SyllabusId);

           
            builder.Property(s => s.Content)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            
            builder.HasOne(s => s.Course)
                .WithOne(c => c.Syllabus)
                .HasForeignKey<Syllabus>(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    
    
}
