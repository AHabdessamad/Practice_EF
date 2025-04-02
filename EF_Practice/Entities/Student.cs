using EF_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practice.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public int StudentNumber { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
