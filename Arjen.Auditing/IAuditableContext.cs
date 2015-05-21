using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arjen.Auditing
{
    public interface IAuditableContext
    {
        DbSet<EntityChange> EntityChanges { get; set; }
        DbSet<EntityChangeField> EntityChangeFields { get; set; } 
    }
}
