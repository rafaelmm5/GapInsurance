using GapInsurance.Service.Controllers;
using System.Web.Http;
using Unity;
using Unity.WebApi;


namespace GapInsurance.Service
{
    public static class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<PolicyController>();

            container.RegisterType<IPolicyManager, PolicyManager>();
            container.RegisterType<IClientManager, ClientManager>();
            container.RegisterType<ICoverageManager, CoverageManager>();

            return container;

            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}