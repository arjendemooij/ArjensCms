using Arjen.IOC;

namespace Cms.Service
{
    public class DependencyBootStrapper
    {
        public void BootStrap()
        {
            IOCController.AutoRegisterInterface(GetType().Assembly);            
        }
    }
}
