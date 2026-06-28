using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni2.Models;

namespace Uni2
{
    internal class UniversityDbContext : DbContext
    {
       
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Courses> Courses { get; set; } = null!;
        public DbSet<Assignments> Assignments { get; set; } = null!;
        public DbSet<Comments> Comments { get; set; } = null!;
        public DbSet<Grades> Grades { get; set; } = null!;
        public DbSet<Syllabus> Syllabuses { get; set; } = null!;

       
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost\SQLEXPRESS;Database=UniversityDb2;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(UniversityDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}