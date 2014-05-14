using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Http.Cors;
using Microsoft.Owin;
using Employees.Data;
using Employees.Model;
using Employees.Services;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Security;

namespace Employees.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
[Authorize]
    public class EmployeeAPIController : ApiController
    {
              private IEmployeeService employeeService;
              public UserManager<IdentityUser> UserManager { get; private set; }

        public EmployeeAPIController()
        { }

        public EmployeeAPIController(IEmployeeService _employeeService, UserManager<IdentityUser> userManager)
              {
                  this.employeeService = _employeeService;
                  this.UserManager = userManager;
              }



       // GET api/EmployeeAPI
     //  [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IEnumerable<Employee> GetEmployees()
        {

            //var  list = employeeService.GetEmployee().ToList();
            //return list;
            var EmployeesDetails = employeeService.GetEmployee();
            return EmployeesDetails;   
        
        }

        // GET api/EmployeeAPI/5
        public Employee GetEmployee(int id)
        {
            //if (System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
            //{ }
         //   UserManager.AddToRole("d912744a-ef08-40a8-b22a-dd80d84e85ee", "Admin");
            var Employee = employeeService.GetEmployeeById(id);
            return Employee;   
            
        }

        // POST api/EmployeeAPI
        public IEnumerable<Employee> Post(Employee value)
        {
            employeeService.AddEmployee(value);
            var EmployeesDetails = employeeService.GetEmployee();
            return EmployeesDetails;
        }

        // PUT api/EmployeeAPI/5
        public void Put(int id, string value)
        {

        }

        // DELETE api/EmployeeAPI/5
        public IEnumerable<Employee> Delete(int Id)
        {
            bool flag= employeeService.DeleteEmployee(Id);
            if (flag)
            {
                var EmployeesDetails = employeeService.GetEmployee();
                return EmployeesDetails;
            }
            else
                return null;
        }
    }
}