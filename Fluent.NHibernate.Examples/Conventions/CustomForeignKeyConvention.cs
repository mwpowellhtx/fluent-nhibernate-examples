using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;

namespace Fluent.NHibernate.Examples.Conventions
{
    public class CustomForeignKeyConvention : ForeignKeyConvention
    {
        protected override string GetKeyName(Member property, Type type)
        {
            if (property != null)
                return property.Name + @"Id";

            return type.Name + @"Id";
        }
    }
}
