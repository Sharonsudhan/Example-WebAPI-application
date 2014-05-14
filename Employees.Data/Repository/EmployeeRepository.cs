using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Data.Infrastructure;
using Employees.Model;

namespace Employees.Data.Repository
{
  public class EmployeeRepository :RepositoryBase<Employee>,IEmployeeRepository
    {

        public EmployeeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }


    }

     public interface IEmployeeRepository : IRepository<Employee>
    {    

    }
}