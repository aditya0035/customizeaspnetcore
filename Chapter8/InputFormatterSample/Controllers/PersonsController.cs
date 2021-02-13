using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InputFormatterSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InputFormatterSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        [HttpPost]
        public ActionResult<IEnumerable<Person>> Post(IEnumerable<Person> persons)
        {
            return Ok(persons);
        }
    }
}
