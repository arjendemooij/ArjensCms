using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arjen.IOC;

namespace Arjen.Auditing
{
    public class EntityChangeAuditor : IEntityChangeAuditor
    {
        public void Audit(DbEntityEntry entityEntry)
        {
            IAuditableContext context = IOCController.GetInstance<IAuditableContext>();
            if (context != null)
            {
                var entity = entityEntry.Entity;

                var change = new EntityChange()
                    {
                        ChangeType = ToChangeType(entityEntry.State),
                        EntityName = entity.GetType().Name,
                        Date = DateTime.Now
                    };
                foreach (var property in entity.GetType().GetProperties())
                {
                    var changeField = new EntityChangeField()
                       {
                           EntityChange = change,
                           Name = property.Name,
                           NewValue = (property.GetValue(entity) ?? "NULL").ToString(),
                           OldValue = "To be implemented"
                       };
                    context.EntityChangeFields.Add(changeField);
                }

                context.EntityChanges.Add(change);
            }
        }



        private EntityChangeType ToChangeType(EntityState state)
        {
            switch (state)
            {
                case EntityState.Added: return EntityChangeType.Create;
                case EntityState.Deleted: return EntityChangeType.Delete;
                case EntityState.Modified: return EntityChangeType.Update;
                default:
                    return EntityChangeType.Unknown;
            }
        }
    }
}
