using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace Fluent.NHibernate.Examples
{
    internal class HibernateSessionManager
    {
        private readonly FluentConfiguration _configuration;

        private readonly ISessionFactory _factory;

        private readonly ISession _session;

        internal HibernateSessionManager()
        {
            _configuration = Fluently.Configure()
                .Database(GetPersistenceConfigurer)
                .Mappings(ConfigureMappings)
                .Mappings(ExportMappingConfiguration)
                .ExposeConfiguration(ExposeConfiguration);

            _factory = _configuration.BuildSessionFactory();

            _session = _factory.OpenSession();
        }

        private IPersistenceConfigurer GetPersistenceConfigurer()
        {
            return new SQLiteConfiguration()
                .ConnectionString(cs => cs.FromConnectionStringWithKey(@"db"));
        }

        private void ConfigureMappings(MappingConfiguration mappings)
        {
            var programType = typeof(Program);

            mappings.FluentMappings.AddFromAssembly(programType.Assembly)
                .Conventions.AddAssembly(programType.Assembly);
        }

        private void ExportMappingConfiguration(MappingConfiguration mappings)
        {
            var fluentMappingsInfo = new DirectoryInfo(@"FluentMappings");

            if (!fluentMappingsInfo.Exists)
                fluentMappingsInfo.Create();

            mappings.FluentMappings.ExportTo(fluentMappingsInfo.FullName);

            Process.Start(fluentMappingsInfo.FullName);
        }

        private void ExposeConfiguration(Configuration configuration)
        {
        }

        internal void Work(Action<ISession> work,
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var transaction = _session.BeginTransaction(isolationLevel))
            {
                try
                {
                    work(_session);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}