using Eisk.Core.WebApi;
using Eisk.Domains.Entities;
using Eisk.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace Eisk.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController : WebApiControllerBase<Employee, int>
{
    public EmployeesController(EmployeeDomainService employeeDomainService) : base(employeeDomainService)
    {

    }
}
