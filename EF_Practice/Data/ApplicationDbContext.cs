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

        protected ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        internal ApplicationDbContext() { }

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

        public DbSet<VTeacherSubject> VTeacherSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasDiscriminator<string>("PersonType")
                .HasValue<Student>("Student")
                .HasValue<Teacher>("Teacher");

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            modelBuilder.Entity<Class>()
               .HasMany(e => e.Enrollments)
               .WithOne(e => e.Class)
               .HasForeignKey(e => e.ClassId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired(false);

            modelBuilder.Entity<Teacher>()
             .HasOne(e => e.Subject)
             .WithOne(e => e.Teacher)
             .HasForeignKey<Teacher>(e => e.SubjectId)
             .IsRequired();

            // Seed Data to DB

            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, FirstName = "Abdessamad", LastName = "Ait hamou" },
                new Person { Id = 2, FirstName = "ALi", LastName = "Mourachid" },
                new Person { Id = 3, FirstName = "Ahmed", LastName = "Moktadir" }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, StudentNumber = 1001 },
                new Student { Id = 2, StudentNumber = 1002 }
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 3, HireDate = DateTime.Parse("2020-01-15"), SubjectId = 1 }
            );


            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, Name = "Programmation", Description = "Algorithme and coding" }
            );

            modelBuilder.Entity<Class>().HasData(
                new Class { Id = 1, Name = "C#" },
                new Class { Id = 2, Name = "ASP.Net" }
            );

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { Id = 1, StudentId = 1, ClassId = 1, EnrollmentDate = DateTime.Now },
                new Enrollment { Id = 2, StudentId = 2, ClassId = 2, EnrollmentDate = DateTime.Now }
            );
        }
    };
 
}
