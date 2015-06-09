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
        private readonly IDbContext _dbContext;

        public QueryContext()
        {            
            _dbContext = IOCController.GetInstance<IDbContext>();            
        }

        public QueryContext Include<T>(Expression<Func<T, object>> path) where T : class
        {
            _dbContext.RelatedObjectsConfiguration.RegisterInclude(path);

            return this;
        }

        public QueryContext NoCache()
        {
            _dbContext.CachingSettings.UseCache = false;

            return this;
        }


        public void Dispose()
        {
            _dbContext.RelatedObjectsConfiguration.Clear();          
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