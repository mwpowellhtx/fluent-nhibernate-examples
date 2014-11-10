using System;
using System.Collections;
using System.Collections.Generic;

namespace Fluent.NHibernate.Examples.Models
{
    public abstract class AbstractCollection<TDerived, TCollectionItem>
        : DomainModel, ICollection<TCollectionItem>
        where TDerived : AbstractCollection<TDerived, TCollectionItem>
        where TCollectionItem : AbstractCollectionItem<TCollectionItem, TDerived>
    {
        public virtual IList<TCollectionItem> Items { get; set; } 

        protected AbstractCollection()
        {
            Initialize();
        }

        private void Initialize()
        {
            Items = new List<TCollectionItem>();
        }

        public virtual void Add(TCollectionItem item)
        {
            Items.Add(item);
            item.Collection = (TDerived) this;
        }

        public virtual void Clear()
        {
            foreach (var item in Items)
                item.Collection = null;
            Items.Clear();
        }

        public virtual bool Contains(TCollectionItem item)
        {
            return Items.Contains(item);
        }

        public virtual void CopyTo(TCollectionItem[] array, int arrayIndex)
        {
            Items.CopyTo(array, arrayIndex);
        }

        public virtual int Count
        {
            get { return Items.Count; }
        }

        public virtual bool IsReadOnly
        {
            get { return Items.IsReadOnly; }
        }

        public virtual bool Remove(TCollectionItem item)
        {
            var removed = Items.Remove(item);
            if (removed) item.Collection = null;
            return removed;
        }

        public virtual IEnumerator<TCollectionItem> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
