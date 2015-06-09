using System;
using System.Collections;
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

        public void RegisterInclude<T>(Expression<Func<T, object>> include) where T : class
        {
            Type type = typeof(T);
            if (!_includeChains.ContainsKey(type))
            {
                _includeChains.Add(type, new List<object>());
            }
            _includeChains[type].Add(include);
        }

        public void Clear()
        {
            _includeChains = new Dictionary<Type, List<object>>();
        }

        public IEnumerable<Expression<Func<T, object>>> GetIncludes<T>()
        {
            Type type = typeof(T);
            if (!_includeChains.ContainsKey(type)) return new List<Expression<Func<T, object>>>();

            var result = new List<Expression<Func<T, object>>>();
            foreach (var includeChain in _includeChains[type])
            {
                var typedIncludeChain = (Expression<Func<T, object>>) includeChain;
                result.Add(typedIncludeChain);
            }

            return result;
        }
    }
}
