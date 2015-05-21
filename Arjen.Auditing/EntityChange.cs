using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arjen.Auditing
{
    public class EntityChange
    {
        public int Id { get; set; }
        [Required]
        public EntityChangeType ChangeType { get; set; }
        [Required]
        public string EntityName { get; set; }
        public IEnumerable<EntityChangeField> Fields { get; set; }
        [Required]
        public DateTime Date { get; set; }

        //todo entity id loggen
        // todo tablename loggen
        // todo change in aparte tabel, details in aparte tabel
    }

    public class EntityChangeField
    {
        public int Id { get; set; }
        public EntityChange EntityChange { get; set; }
        [Required]
        public string Name { get; set; }        
        public string NewValue { get; set; }
        public string OldValue { get; set; }

    }
}