using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw06.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw06.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private IStudentsDbService _dbService;

        public StudentsController(IStudentsDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(string id)
        {

            return Ok(_dbService.GetStudent(id));
        }
    }
}