using Microsoft.Practices.Unity;
using Paylocity.API.Models.Repository;
using System.Web.Http;
using Unity.WebApi;

namespace Paylocity.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IBenefitRepository, BenefitRepository>();
            container.RegisterType<IDependentRepository, DependentRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}