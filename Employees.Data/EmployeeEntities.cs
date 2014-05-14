using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Employees.Model;

namespace Employees.Data
{
    public class EmployeeEntities :IdentityDbContext<IdentityUser>
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
