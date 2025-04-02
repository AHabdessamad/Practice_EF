using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practice.Entities
{
    public enum Level { Beginner, Intermediate, Advanced }
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Level Level { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
