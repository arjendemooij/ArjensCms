using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arjen.Reflection
{
    public static class ReflectionExtensions
    {
        public static bool HasInterface<TInterface>(this Type type)
        {
            return type.GetInterfaces().Contains(typeof(TInterface));
        }

        public static bool IsEnumerableType(this Type type)
        {
            return type.GetInterfaces().Contains(typeof (IEnumerable));
        }

        public static Type GetEnumerableItemType(this Type type)
        {
            return type.GetGenericArguments().First();
        }
    }
}
