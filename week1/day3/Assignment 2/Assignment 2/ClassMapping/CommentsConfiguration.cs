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
    internal class CommentsConfiguration : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.ToTable("Comments");

            
            builder.HasKey(c => c.CommentId);

         
            builder.Property(c => c.CreatedDate)
                .IsRequired();

            builder.Property(c => c.CommentContent)
                .HasColumnType("nvarchar(max)");

            builder.HasOne(c => c.Assignment)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.AssignmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.CreatedByUser)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    
    }

