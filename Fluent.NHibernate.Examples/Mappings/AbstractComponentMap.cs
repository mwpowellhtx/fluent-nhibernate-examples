using Fluent.NHibernate.Examples.Models;
using FluentNHibernate.Mapping;

namespace Fluent.NHibernate.Examples.Mappings
{
    public abstract class AbstractComponentMap<T> : ComponentMap<T>
        where T : DomainModel
    {
        protected AbstractComponentMap()
        {
            Initialize();
        }

        private void Initialize()
        {
            Map(x => x.Id);
        }
    }
}
