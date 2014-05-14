using System;
using Employees.Data;

namespace Employees.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        EmployeeEntities Get();
    }
}
