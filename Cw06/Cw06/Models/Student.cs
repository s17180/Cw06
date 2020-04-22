using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw06.Models
{
    public class Student
    {
        public string IdStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int IdEnrollment { get; set; }
        public override string ToString()
        {
            return "{ " + FirstName + ", " + LastName + ", " + IdStudent + " }";
        }

    }
}
