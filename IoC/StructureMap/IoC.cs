using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using SignalR;
using StructureMap;
using StructureMap.ServiceLocatorAdapter;

namespace IoC.StructureMap
{
    public static class IoC
    {
        public static void Initialize()
        {
            // Structure map initialization
            ObjectFactory.Initialize(x =>
            {
                // TODO: Add registries

                // TODO: Conventional scanning
                x.Scan(scan =>
                {
                    scan.Assembly(Assembly.GetExecutingAssembly());
                    scan.WithDefaultConventions();
                });

                // MVC framework
                x.For<IFilterProvider>().Use<StructureMapMvcFilterProvider>();
            });

            var container = ObjectFactory.Container;

            // Common service locator
            ServiceLocator.SetLocatorProvider(() => new StructureMapServiceLocator(container));

            // Built-in MVC dependency resolver
            DependencyResolver.SetResolver(new StructureMapMvcDependencyResolver(container));

            // Built-in Web API dependency resolver
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapHttpDependencyResolver(container);

            // SignalR dependency resolver
            GlobalHost.DependencyResolver = new StructureMapSignalRDependencyResolver(container);
        }
    }
}