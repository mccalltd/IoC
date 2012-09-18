using System.Web.Mvc;
using StructureMap;

namespace IoC.StructureMap
{
    /// <summary>
    /// Wrapper for IDependencyResolver in System.Web.Mvc. 
    /// </summary>
    public class StructureMapMvcDependencyResolver : StructureMapDependencyResolverBase, IDependencyResolver
    {
        public StructureMapMvcDependencyResolver(IContainer container) : base(container) { }
    }
}