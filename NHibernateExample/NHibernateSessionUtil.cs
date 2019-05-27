using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace NHibernateExample
{
    public class NHibernateSessionUtil
    {
        private static ISessionFactory _sessionFactory;

        private static ISession _ISession;

        private NHibernateSessionUtil()
        {
            System.Diagnostics.Debug.WriteLine("NHibernateSessionUtil|NHibernateSessionUtil|start...");
        }

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();

                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            try
            {
                _sessionFactory = Fluently.Configure()
                    .Database(MySQLConfiguration.Standard.ConnectionString("Server = localhost; Port = 3306; Database =onlineshop; Uid = root; Pwd =password;").ShowSql())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateSessionUtil>())
                    .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                    .BuildSessionFactory();
                _ISession = SessionFactory.OpenSession();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR InitializeSessionFactory | " + e.Message);
            }
        }

        public static ISession GetSession()
        {
            System.Diagnostics.Debug.WriteLine("GetSession....");
            try
            {
                if (_ISession == null || !_ISession.IsOpen || !_ISession.IsConnected)
                {
                    System.Diagnostics.Debug.WriteLine("NHibernateSessionUtil IS NULL / NOT OPEN / IS NOT CONNECTED!");
                    InitializeSessionFactory();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR GetSession | " + e.Message);

            }
            return _ISession;
        }
    }
}