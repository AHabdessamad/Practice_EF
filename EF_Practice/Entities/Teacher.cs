using EF_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practice.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public DateTime HireDate {  get; set; }

        public int PersonId {  get; set; }
        public Person Person { get; set; } = null!;

        public int SubjectId {  get; set; }
        public Subject Subject { get; set; } = null!;
    }
}
