using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Reflection;
using Employees.Data;
using Employees.Data.Repository;
using Employees.Data.Infrastructure;
using Employees.Services;
//using Employees.Web.Core.Authentication;
using Microsoft.AspNet.Identity.EntityFramework;
using Employees.Models;
using Microsoft.AspNet.Identity;
using Employees.Controllers;
using System.Web.Http;

namespace Employees
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            //Configure AutoMapper
            //AutoMapperConfiguration.Configure();
        }
        public static void SetAutofacContainer()
        {

            //var builder = new ContainerBuilder();
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerHttpRequest();
            //builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerHttpRequest();
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
            //builder.RegisterAssemblyTypes(typeof(EmployeeRepository).Assembly).Where(t => t.Name.EndsWith("Repository"))
            //    .AsImplementedInterfaces().InstancePerHttpRequest();

            ////    builder.RegisterFilterProvider();
            //IContainer container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            try
            {

                var ApiBuilder = new ContainerBuilder();
                ApiBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
                ApiBuilder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerHttpRequest();
                ApiBuilder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerHttpRequest();
                ApiBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
                ApiBuilder.RegisterAssemblyTypes(typeof(EmployeeRepository).Assembly).Where(t => t.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces().InstancePerHttpRequest();

                ApiBuilder.Register(c => new UserManager<IdentityUser>(new UserStore<IdentityUser>(new EmployeeEntities())))
            .As<UserManager<IdentityUser>>().InstancePerHttpRequest();

                IContainer ApiContainer = ApiBuilder.Build();
                GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(ApiContainer);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}