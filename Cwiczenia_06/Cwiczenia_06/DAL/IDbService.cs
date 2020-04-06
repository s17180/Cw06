using Cwiczenia_03.Models;
using System.Collections.Generic;

namespace Cwiczenia_03.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
    }
}
