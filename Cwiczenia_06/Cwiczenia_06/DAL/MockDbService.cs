using Cwiczenia_03.Models;
using System;
using System.Collections.Generic;

namespace Cwiczenia_03.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;


        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student { IdStudent = 1, FirstName = "Michal", LastName = "Barszcz" },
                new Student { IdStudent = 2, FirstName = "Jan", LastName = "Nowak" },
                new Student { IdStudent = 3, FirstName = "Sebastian", LastName = "Mucha"  }
            };
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}
