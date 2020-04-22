using Cw06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw06.Services
{
    public interface IStudentsDbService
    {
        public bool CheckIfExists(string index);
        public Student GetStudent(string index);


    }
}
