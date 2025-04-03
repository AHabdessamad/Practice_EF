using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practice.Entities
{
    public class VTeacherSubject
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public string SubjectName { get; set; } = string.Empty;
    }
}
