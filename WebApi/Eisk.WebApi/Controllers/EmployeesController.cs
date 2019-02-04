using System.Collections.Generic;
using Eisk.Domains.Employee;
using Eisk.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace Eisk.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private EmployeeDomainService _employeeDomainService;
        public EmployeesController(EmployeeDomainService ctx)
        {
            _employeeDomainService = ctx;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeDomainService.GetAll();
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _employeeDomainService.GetById(id);
        }

        [HttpPost]
        public void Post(Employee employee)
        {
            _employeeDomainService.Add(employee);
        }

        [HttpPut("{id}")]
        public void Put(int id, Employee employee)
        {
            _employeeDomainService.Update(id, employee);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeeDomainService.Delete(id);
        }
    }
}
