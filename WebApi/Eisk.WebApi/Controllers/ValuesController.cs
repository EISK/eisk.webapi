using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Eisk.EntityFrameworkCore.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace Eisk.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private InMemoryDbContext _ctx;
        public ValuesController(InMemoryDbContext ctx)
        {
            _ctx = ctx;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { _ctx.Employees.First().FirstName };
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
