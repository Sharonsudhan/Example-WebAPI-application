using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Model;
using Employees.Data.Repository;
using Employees.Data.Infrastructure;

namespace Employees.Services
{
    public   interface IEmployeeService
    {
      IEnumerable<Employee> GetEmployee();
      Employee GetEmployeeById(int Id);
      bool DeleteEmployee(int Id);

      void AddEmployee(Employee employee);
      void SaveEmployees();
       
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IUnitOfWork unitOfWork;


        public EmployeeService(IEmployeeRepository _employeeRepository, IUnitOfWork _unitOfWork)
        {

            this.employeeRepository = _employeeRepository;
            this.unitOfWork = _unitOfWork;
        }
       
       public IEnumerable<Employee> GetEmployee()
        {
           var employeesList= employeeRepository.GetAll();
           return employeesList;
        }

        public Employee GetEmployeeById(int Id)
       {
           var employeesList = employeeRepository.GetById(Id);
           return employeesList;
       }

        public bool DeleteEmployee(int Id)
        {
              var employeesList = employeeRepository.GetById(Id);
              if (employeesList != null)
              {
                  employeeRepository.Delete(employeesList);
                  SaveEmployees();
                  return true;
              }
              else
                  return false;
        }

        public void AddEmployee(Employee employee)
        {
            employeeRepository.Add(employee);
            SaveEmployees();
        }

        public void SaveEmployees()
        {
            unitOfWork.Commit();
        }

    }
}

