using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw06.Controllers
{
    [Route("api/enrollo")]
    [ApiController]
    public class EnrolloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("hehe");
        }
    }
}