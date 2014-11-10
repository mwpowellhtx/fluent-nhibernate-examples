namespace Fluent.NHibernate.Examples.Models
{
    public abstract class AbstractCollectionItem<TDerived, TCollection> : DomainModel
        where TCollection : AbstractCollection<TCollection, TDerived>
        where TDerived : AbstractCollectionItem<TDerived, TCollection>
    {
        public virtual TCollection Collection { get; set; }

        protected AbstractCollectionItem()
        {
        }
    }
}
