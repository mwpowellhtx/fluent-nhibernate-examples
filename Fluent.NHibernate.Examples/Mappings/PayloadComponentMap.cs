using Fluent.NHibernate.Examples.Models;

namespace Fluent.NHibernate.Examples.Mappings
{
    public class PayloadComponentMap : AbstractComponentMap<Payload>
    {
        public PayloadComponentMap()
        {
            Initialize();
        }

        private void Initialize()
        {
            Map(x => x.Name)
                .Length(127)
                .Not.Nullable();

            Map(x => x.Value)
                .Not.Nullable();
        }
    }
}
