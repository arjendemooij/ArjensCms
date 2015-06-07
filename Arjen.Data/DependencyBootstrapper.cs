using Arjen.IOC;

namespace Arjen.Data
{
    public class DependencyBootStrapper
    {
        public void BootStrap()
        {
            IOCController.Register(typeof (IRepository<>), typeof (Repository<>));
        }
    }
}
