using Employees.Data;
using Employees.Data.Infrastructure;

namespace Employees.Data.Infrastructure
{
public class DatabaseFactory : Disposable, IDatabaseFactory
{
    private EmployeeEntities dataContext;
    public EmployeeEntities Get()
    {
        return dataContext ?? (dataContext = new EmployeeEntities());
    }
    protected override void DisposeCore()
    {
        if (dataContext != null)
            dataContext.Dispose();
    }
}
}
