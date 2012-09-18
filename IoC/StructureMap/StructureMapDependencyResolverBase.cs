using System;
using System.Collections.Generic;
using System.Linq;
using StructureMap;

namespace IoC.StructureMap
{
    /// <summary>
    /// Contains service location logic shared by dependency resolvers. 
    /// </summary>
    public abstract class StructureMapDependencyResolverBase
    {
        protected readonly IContainer Container;

        protected StructureMapDependencyResolverBase(IContainer container)
        {
            Container = container;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
                return null;

            try
            {
                return serviceType.IsAbstract || serviceType.IsInterface
                           ? Container.TryGetInstance(serviceType)
                           : Container.GetInstance(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Container.GetAllInstances(serviceType).Cast<object>();
        }
    }
}