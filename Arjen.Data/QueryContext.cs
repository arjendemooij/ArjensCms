using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Arjen.IOC;

namespace Arjen.Data
{

    /// <summary>
    /// don't nest usings of this
    /// </summary>
    public class QueryContext : IDisposable
    {
        private readonly IObjectContext _objectContext;

        public QueryContext()
        {            
            _objectContext = IOCController.GetInstance<IObjectContext>();            
        }

        public QueryContext Include<T, TProperty>(Expression<Func<T, TProperty>> path) where T : class
        {
            Func<IQueryable<T>, IQueryable<T>> func = (set) => set.Include(path);
            _objectContext.RelatedObjectsConfiguration.RegisterInclude(func);

            return this;
        }

        public QueryContext NoCache()
        {
            _objectContext.CachingSettings.UseCache = false;

            return this;
        }


        public void Dispose()
        {
            _objectContext.RelatedObjectsConfiguration.Clear();          
        }
    }

    //public class RelatedObjectsConfigurationManager
    //{
    //    public static void Clear()
    //    {
    //        RelatedObjectsConfiguration.GetInstance().Clear();
    //    }

    //    public static IQueryable<T> AddIncludes<T>(IQueryable<T> query)
    //    {
    //        return RelatedObjectsConfiguration.GetInstance().AddIncludesToQuery(query);
    //    }

    //    public static void RegisterInclude<T, TProperty>(Expression<Func<T, TProperty>> path) where T : class
    //    {
    //        Func<IQueryable<T>, IQueryable<T>> func = (set) => set.Include(path);

    //        RelatedObjectsConfiguration.GetInstance().RegisterInclude(func);
    //    }
    //}
}