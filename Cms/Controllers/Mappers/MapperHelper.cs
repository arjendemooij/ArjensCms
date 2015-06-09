using System.Linq;
using System.Reflection;
using Arjen.Data;
using AutoMapper;

namespace Cms.Controllers.Mappers
{
    public class MapperHelper
    {
        public static void RequireMap<TSource, TDestination>(bool ignoreNavigationProperties = true)
        {
            if (Mapper.FindTypeMapFor<TSource, TDestination>() == null)
            {
                var map = Mapper.CreateMap<TSource, TDestination>();
                if (ignoreNavigationProperties)
                    map.IgnoreNavigationProperties();
            }
        }
    }

    public static class AutomapExtensions
    {

        public static IMappingExpression<TSource, TDestination> IgnoreNavigationProperties<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);

            foreach (PropertyInfo sourceProperty in sourceType.GetProperties())
            {
                var targetProperty = typeof(TDestination).GetProperty(sourceProperty.Name);
                if (targetProperty != null)
                {
                    var targetPropertyType = targetProperty.PropertyType;
                    var isSingleNavigationProperty = targetPropertyType.GetInterfaces().Contains(typeof (IHasId));

                    if (isSingleNavigationProperty)
                        expression.ForMember(targetProperty.Name, opt => opt.Ignore());
                }
            }
            return expression;
        }
    }
}