using EF_Practice.Data;
using EF_Practice.Entities;
using EF_Practice.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practice.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _context = new ApplicationDbContext();

        public IReadOnlyRepository<Student>? studentReadOnlyRepository;
        public IRepository<Student>? studentRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IReadOnlyRepository<Student> StudentReadOnlyRepository
        {
            get
            {
                if ( this.studentReadOnlyRepository == null)
                {
                    this.studentReadOnlyRepository = new GenericReadOnlyRepository<Student>(_context);
                }
                return studentReadOnlyRepository;
            }
        }

        public IRepository<Student> StudentRepository
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(_context);
                }
                return studentRepository;

            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
