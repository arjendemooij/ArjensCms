using Arjen.IOC;
using log4net;

namespace Arjen.Logging
{
    public class DependencyBootStrapper
    {
        public void BootStrap()
        {
           IOCController.RegisterFactoryMethod<ILog>(()=>LogManager.GetLogger("ROOT"));
        }

    }
}
