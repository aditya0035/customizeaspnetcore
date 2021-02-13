using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBinderSample.ModelBinders;
using ModelBinderSample.Models;

namespace ModelBinderSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        [HttpPost]
        public ActionResult<IEnumerable<Person>> Post([FromForm][ModelBinder(BinderType = typeof(PersonModelBinder),Name = "persons")]IEnumerable<Person> persons)
        {
            return Ok(persons);
        }
    }
}
