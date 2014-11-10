using Fluent.NHibernate.Examples.Models;
using FluentNHibernate.Mapping;

namespace Fluent.NHibernate.Examples.Mappings
{
    public abstract class DomainModelMap<T> : ClassMap<T>
        where T : DomainModel
    {
        /// <summary>
        /// Gets the TableName.
        /// </summary>
        protected virtual string TableName
        {
            get { return typeof (T).Name + @"s"; }
        }

        protected DomainModelMap()
        {
            Initialize();
        }

        private void Initialize()
        {
            Table(TableName);

            Id(x => x.Id);
        }
    }
}
