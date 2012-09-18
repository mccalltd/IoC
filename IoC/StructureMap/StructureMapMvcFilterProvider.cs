using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StructureMap;

namespace IoC.StructureMap
{
    public class StructureMapMvcFilterProvider : FilterAttributeFilterProvider
    {
        private readonly IContainer _container;

        public StructureMapMvcFilterProvider(IContainer container)
        {
            _container = container;
        }

        public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor).ToArray();

            foreach (var filter in filters)
                _container.BuildUp(filter.Instance);

            return filters;
        }
    }
}