using Fluent.NHibernate.Examples.Models;

namespace Fluent.NHibernate.Examples.Mappings
{
    public abstract class AbstractCollectionItemMap<TCollectionItem, TCollection>
        : DomainModelMap<TCollectionItem>
        where TCollectionItem : AbstractCollectionItem<TCollectionItem, TCollection>
        where TCollection : AbstractCollection<TCollection, TCollectionItem>
    {
        protected AbstractCollectionItemMap()
        {
            Initialize();
        }

        private void Initialize()
        {
            References(x => x.Collection, @"CollectionId")
                .Nullable();
        }
    }
}
