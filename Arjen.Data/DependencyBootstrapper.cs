using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace Arjen.Data
{
    public class DependencyBootStrapper
    {
        public void BootStrap()
        {
            ObjectFactory.Configure(x =>
                {
                    x.For(typeof (IRepository<>)).Use(typeof (Repository<>));
                });
        }
    }
}
