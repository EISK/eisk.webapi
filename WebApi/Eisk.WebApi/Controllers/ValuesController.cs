using System.Collections.Generic;
using Eisk.Domains.Employee;
using Eisk.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace Eisk.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private EmployeeDomainService _ctx;
        public ValuesController(EmployeeDomainService ctx)
        {
            _ctx = ctx;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _ctx.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value.";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
