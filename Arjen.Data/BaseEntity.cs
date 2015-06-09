using System.ComponentModel.DataAnnotations.Schema;

namespace Arjen.Data
{
    public class BaseEntity : IObjectState
    {
        [NotMapped]
        public ObjectState State { get; set; }
    }
}