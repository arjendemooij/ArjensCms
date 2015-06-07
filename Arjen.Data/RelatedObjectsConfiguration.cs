using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Arjen.Data
{
    public class RelatedObjectsConfiguration
    {
        public RelatedObjectsConfiguration()
        {
            _includeChains = new Dictionary<Type, List<object>>();
        }

        private Dictionary<Type, List<object>> _includeChains;

        public void RegisterInclude<T>(Func<IQueryable<T>, IQueryable<T>> include) where T : class
        {
            Type type = typeof(T);
            if (!_includeChains.ContainsKey(type))
            {
                _includeChains.Add(type, new List<object>());
            }
            _includeChains[type].Add(include);
        }

        public IQueryable<T> AddIncludesToQuery<T>(IQueryable<T> query)
        {
            Type type = typeof(T);
            if (!_includeChains.ContainsKey(type)) return query;

            foreach (var includeChain in _includeChains[type])
            {
                var typedIncludeChain = (Func<IQueryable<T>, IQueryable<T>>)includeChain;
                query = typedIncludeChain(query);
            }

            return query;
        }


        public void Clear()
        {
            _includeChains = new Dictionary<Type, List<object>>();
        }
    }
}
