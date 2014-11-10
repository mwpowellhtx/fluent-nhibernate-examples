using Fluent.NHibernate.Examples.Models;

namespace Fluent.NHibernate.Examples.Mappings
{
    public class PayloadCollectionItemMap : AbstractCollectionItemMap<PayloadCollectionItem, PayloadCollection>
    {
        public PayloadCollectionItemMap()
        {
            Initialize();
        }

        private void Initialize()
        {
            Component(x => x.Payload).ColumnPrefix(@"Payload");
        }
    }
}
