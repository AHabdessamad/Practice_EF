

using EF_Practice.Data;
using EF_Practice.Repositories;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;

namespace EF_Practice
{
    class Program
    {
        private static ApplicationDbContext _context;
        public static void Main(string[] args)
        {
            var container = new Container();
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<UnitOfWork>(Lifestyle.Scoped);

            container.Verify();

            using (var scope = AsyncScopedLifestyle.BeginScope(container))
            {
                var unitOfWork = container.GetInstance<UnitOfWork>();
                var teachers = unitOfWork._context.Teachers.ToList();

                foreach (var teacher in teachers)
                {
                    Console.WriteLine($"Teacher: {teacher.FirstName} {teacher.LastName}, Hired: {teacher.HireDate}, Subject: {teacher.Subject.Name}");
                }
            }

            Console.ReadKey();

        }
    }
}