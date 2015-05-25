using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Cms.Controllers.Mappers
{
    public class MapperHelper   
    {
        public static void RequireMap<TSource, TDestination>()
        {
            if (Mapper.FindTypeMapFor<TSource, TDestination>() == null)
            {
                Mapper.CreateMap<TSource, TDestination>();
            }   
        }
    }
}