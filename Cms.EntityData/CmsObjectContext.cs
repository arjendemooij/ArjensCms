using System;
using System.Data.Entity;
using System.IO;
using Arjen.Auditing;
using Arjen.Data;
using Arjen.Data.UnitOfWork;
using Arjen.IOC;
using Cms.Data;
using Cms.EntityData.Migrations;
using InteractivePreGeneratedViews;
using System.Linq;
using log4net;

namespace Cms.EntityData
{

    public class CmsObjectContext : DbContext, IUnitOfWork, IObjectContext, IAuditableContext
    {
        private static readonly ILog QueryLogger = LogManager.GetLogger("QueryLogger");
        private static bool _interactiveViewsSet = false;


        public DbSet<Page> Pages { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<EntityChange> EntityChanges { get; set; }
        public DbSet<EntityChangeField> EntityChangeFields { get; set; }


        private readonly IEntityChangeAuditor _entityChangeAuditor;


        public CmsObjectContext()
        {
            

            if (IOCController.IsAvailable())
            {
                _entityChangeAuditor = IOCController.GetInstance<IEntityChangeAuditor>();
            }

            if (!_interactiveViewsSet)
            {
                var path = @"C:\Temp\";
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                InteractiveViews.SetViewCacheFactory(this, new FileViewCacheFactory(Path.Combine(path, "CmsEfViews.xml")));
                _interactiveViewsSet = true;
            }


            Database.Log = s => QueryLogger.Debug(s);


        }

        public void Save()
        {
            if (_entityChangeAuditor != null)
            {
                var changes = this.ChangeTracker.Entries().ToList();
                foreach (var dbEntityEntry in changes)
                {
                    _entityChangeAuditor.Audit(dbEntityEntry);
                }
            }

            SaveChanges();

        }

        public void Cancel()
        {
            Dispose();

        }

        public IObjectContext GetObjectContext()
        {
            return this;
        }

        public static void UpdateDatabase()
        {
            //_interactiveViewsSet = true;
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CmsObjectContext, Configuration>());
            //new CmsObjectContext().Database.Initialize(true);
            //_interactiveViewsSet = false;
        }
    }
}
