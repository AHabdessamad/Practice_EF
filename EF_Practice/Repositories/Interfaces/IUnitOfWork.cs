using EF_Practice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practice.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // for Student entity
        IRepository<Student> StudentRepository { get; }
        IReadOnlyRepository<Student> StudentReadOnlyRepository { get; }
        void Save();
    }
}
