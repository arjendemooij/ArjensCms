using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using Arjen.Auditing;
using Arjen.Cache;
using Arjen.Data;
using Arjen.IOC;
using Cms.Models;
using InteractivePreGeneratedViews;
using log4net;
using System.Linq;

namespace Cms.EntityData
{

    public class CmsObjectContext : DbContext, IDbContext, IAuditableContext
    {
        private static readonly ILog QueryLogger = LogManager.GetLogger("QueryLogger");
        private static bool _interactiveViewsSet = false;

        public DbSet<Page> Pages { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<EntityChange> EntityChanges { get; set; }
        public DbSet<EntityChangeField> EntityChangeFields { get; set; }

        public RelatedObjectsConfiguration RelatedObjectsConfiguration { get; set; }
        public CachingSettings CachingSettings { get; set; }

        private readonly IEntityChangeAuditor _entityChangeAuditor;
        private readonly IEntityCache _entityCache;


        public CmsObjectContext()
        {
            RelatedObjectsConfiguration = new RelatedObjectsConfiguration();
            CachingSettings = new CachingSettings();

            
            if (IOCController.IsAvailable())
            {
                _entityCache = IOCController.GetInstance<IEntityCache>();
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


        public override int SaveChanges()
        {
            //AuditChanges();
            FixCachedItems();
            InvalidateCache();

            return base.SaveChanges();
        }

        private void InvalidateCache()
        {
            var changeStates = new[] {EntityState.Added, EntityState.Deleted, EntityState.Modified};
            var changes = this.ChangeTracker.Entries().ToList();
            foreach (var entry in changes)
            {
                if (changeStates.Contains(entry.State))
                {
                    var type = entry.Entity.GetType();
                    _entityCache.InvalidateCache(type);
                }
            }
        }

        private void FixCachedItems()
        {
            var changes = this.ChangeTracker.Entries().ToList();

            var entities = changes.Select(dbEntityEntry => dbEntityEntry.Entity).ToList();

            foreach (var entity in entities)
            {
                foreach (var property in entity.GetType().GetProperties())
                {
                    if (property.IsNavigationProperty())
                    {
                        object value = property.GetValue(entity);
                        if (value != null && _entityCache.ContainsItem(value))
                        {
                            var change = changes.Single(c => c.Entity == value);
                            if(change.State == EntityState.Added)
                                change.State = EntityState.Unchanged;

                            var uncachedValue = Set(value.GetType()).Find(property.GetIdValue(value));
                            property.SetValue(entity, uncachedValue);
                        }
                    }
                }
            }
        }

        private void AuditChanges()
        {
            if (_entityChangeAuditor != null)
            {
                var changes = this.ChangeTracker.Entries().ToList();
                foreach (var dbEntityEntry in changes)
                {
                    _entityChangeAuditor.Audit(dbEntityEntry);
                }
            }
        }

        public void Cancel()
        {
            Dispose();

        }

        public Arjen.Data.IDbContext GetObjectContext()
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
