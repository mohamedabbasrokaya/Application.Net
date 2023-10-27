using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class Student
    {
        public Student()
        {
            Results = new HashSet<Result>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;
        public string StudentAdress { get; set; } = null!;
        public string? Phone { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}
