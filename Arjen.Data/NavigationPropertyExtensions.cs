using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Arjen.Reflection;

namespace Arjen.Data
{
    public static class NavigationPropertyExtensions
    {
        public static bool IsNavigationProperty(this PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType.HasInterface<IHasId>();
        }

        public static int GetIdValue(this PropertyInfo propertyInfo, object record)
        {
            var idProperty = propertyInfo.PropertyType.GetProperty("Id");
            return (int) idProperty.GetValue(record);
        }
    }
}
