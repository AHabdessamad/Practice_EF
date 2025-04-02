using EF_Practice.Entities;
using EF_Practice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practice.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Add this constructor for design-time support
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("Database");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
               .HasOne(e => e.Student)
               .WithOne(e => e.Person)
               .HasForeignKey<Student>(e => e.PersonId)
               .IsRequired();

            modelBuilder.Entity<Person>()
             .HasOne(e => e.Teacher)
             .WithOne(e => e.Person)
             .HasForeignKey<Teacher>(e => e.PersonId)
             .IsRequired();

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .IsRequired(false);

            modelBuilder.Entity<Class>()
               .HasMany(e => e.Enrollments)
               .WithOne(e => e.Class)
               .HasForeignKey(e => e.ClassId)
               .IsRequired(false);

            modelBuilder.Entity<Teacher>()
             .HasOne(e => e.Subject)
             .WithOne(e => e.Teacher)
             .HasForeignKey<Teacher>(e => e.SubjectId)
             .IsRequired();
        }
    };
 
}
