

using Arjen.IOC;

namespace Arjen.Auditing
{
    public class DependencyBootStrapper
    {
        public void BootStrap()
        {
           IOCController.Register<IEntityChangeAuditor, EntityChangeAuditor>();
        }

    }
}
