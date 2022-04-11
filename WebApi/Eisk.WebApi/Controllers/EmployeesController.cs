namespace Eisk.WebApi.Controllers
{
    using Eisk.Core.WebApi;
    using Domains.Entities;
    using DomainServices;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : WebApiControllerBase<Employee, int>
    {
        public EmployeesController(EmployeeDomainService employeeDomainService):base(employeeDomainService)
        {
            
        }
    }
}
