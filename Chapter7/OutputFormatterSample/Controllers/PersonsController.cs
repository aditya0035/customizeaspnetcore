using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenFu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OutputFormatterSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            var Person = A.ListOf<Person>(25);
            return Person;
        }
    }
}
