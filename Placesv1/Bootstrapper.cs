using System.Web.Http;
using Microsoft.Practices.Unity;
using Placesv1.Model;
using Placesv1.Repository;

namespace Placesv1.Web.API
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // e.g. container.RegisterType<ITestService, TestService>();            
            container.RegisterType<IUserRepository, UserRepository>();

            return container;
        }
    }
}