using System.Web.Http.Dependencies;
using StructureMap;

namespace IoC.StructureMap
{
    /// <summary>
    /// Wrapper for IDependencyResolver in System.Web.Http. 
    /// </summary>
    public class StructureMapHttpDependencyResolver : StructureMapDependencyResolverBase, IDependencyResolver
    {
        public StructureMapHttpDependencyResolver(IContainer container) : base(container) { }

        public IDependencyScope BeginScope()
        {
            var isolatedContainer = Container.GetNestedContainer();
            return new StructureMapHttpDependencyResolver(isolatedContainer);
        }

        public void Dispose()
        {
            Container.Dispose();
        }
    }
}