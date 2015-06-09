//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Arjen.Cache;
//using Arjen.Data;
//using Cms.Data;
//using Cms.Data.IData;
//using System.Data.Entity;


//namespace Cms.EntityData.Data
//{
//    public class PageData : BaseData<Page>, IPageData
//    {
//        protected override IQueryable<Page> AddDefaultIncludes(IQueryable<Page> baseQuery)
//        {
//            return baseQuery.Include(x => x.Author);
//        }
        
//        public PageData(IRepository<Page> repository, IEntityCache entityCache)
//            : base(repository, entityCache)
//        {
//        }

//        public IEnumerable<Page> GetAllWithName(string name)
//        {
//            return GetBaseQuery().Where(x => x.Name == name);
//        }

        
//    }
//}
