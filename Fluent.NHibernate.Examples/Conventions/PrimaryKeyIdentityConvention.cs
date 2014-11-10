using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Fluent.NHibernate.Examples.Conventions
{
    public class PrimaryKeyIdentityConvention : IIdConvention
    {
        /// <summary>
        /// Applies the convention to the given <see cref="IIdentityInstance"/>.
        /// </summary>
        /// <param name="instance"></param>
        public void Apply(IIdentityInstance instance)
        {
            instance.Column(@"Id");
        }
    }
}
