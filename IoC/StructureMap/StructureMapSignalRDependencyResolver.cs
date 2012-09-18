using System;
using System.Collections.Generic;
using System.Linq;
using SignalR;
using StructureMap;

namespace IoC.StructureMap
{
    /// <summary>
    /// Wrapper for IDependencyResolver in SignalR. 
    /// We use the default dependency resolver for implementation of the Register overloads.
    /// </summary>
    public class StructureMapSignalRDependencyResolver : DefaultDependencyResolver
    {
        private readonly InnerStructureMapSignalRDependencyResolver _innerDependencyResolver;

        public StructureMapSignalRDependencyResolver(IContainer container)
        {
            _innerDependencyResolver = new InnerStructureMapSignalRDependencyResolver(container);
        }

        public override object GetService(Type serviceType)
        {
            return _innerDependencyResolver.GetService(serviceType) ?? base.GetService(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return _innerDependencyResolver.GetServices(serviceType).Concat(base.GetServices(serviceType));
        }

        private class InnerStructureMapSignalRDependencyResolver : StructureMapDependencyResolverBase
        {
            public InnerStructureMapSignalRDependencyResolver(IContainer container) : base(container) {}
        }
    }
}