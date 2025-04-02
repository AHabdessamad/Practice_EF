using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practice.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        public int ClassId { get; set; }
        public Class Class { get; set; } = null!;

        public DateTime EnrollmentDate {  get; set; }
    }
}
