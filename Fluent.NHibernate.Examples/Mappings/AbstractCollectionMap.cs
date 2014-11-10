using Fluent.NHibernate.Examples.Models;

namespace Fluent.NHibernate.Examples.Mappings
{
    public abstract class AbstractCollectionMap<TCollection, TCollectionItem>
        : DomainModelMap<TCollection>
        where TCollection : AbstractCollection<TCollection, TCollectionItem>
        where TCollectionItem : AbstractCollectionItem<TCollectionItem, TCollection>
    {
        protected AbstractCollectionMap()
        {
            Initialize();
        }

        private void Initialize()
        {
            HasMany(x => x.Items)
                .Inverse()
                .KeyColumn(@"CollectionId")
                .Cascade.AllDeleteOrphan();
        }
    }
}
