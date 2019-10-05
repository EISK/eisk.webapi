namespace Eisk.WebApi.Controllers
{
    using Eisk.Core.WebApi;
    using Domains.Entities;
    using DomainServices;

    public class EmployeesController : WebApiControllerBase<Employee,int>
    {
        public EmployeesController(EmployeeDomainService employeeDomainService):base(employeeDomainService)
        {
            throw new System.Exception("test");
        }
    }
}
