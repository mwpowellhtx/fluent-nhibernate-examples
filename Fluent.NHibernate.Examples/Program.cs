using System.Diagnostics;
using System.Linq;
using Fluent.NHibernate.Examples.Models;
using FluentNHibernate.Cfg;

namespace Fluent.NHibernate.Examples
{
    internal static class Program
    {

        private static void Main(string[] args)
        {
            var hsm = new HibernateSessionManager();

            long collectionId = 0;

            hsm.Work(s =>
            {
                var collection = new PayloadCollection();

                s.SaveOrUpdate(collection);

                collectionId = collection.Id;

                Debug.Assert(collectionId > 0);
            });

            hsm.Work(s =>
            {
                var collection = s.Get<PayloadCollection>(collectionId);

                var item = new PayloadCollectionItem();

                collection.Add(item);

                s.SaveOrUpdate(collection);

                //Debug.Assert(item.Id > 0);
            });

            hsm.Work(s =>
            {
                var collection = s.Get<PayloadCollection>(collectionId);

                var item = collection.First();

                collection.Remove(item);

                s.SaveOrUpdate(collection);
            });
        }
    }
}
