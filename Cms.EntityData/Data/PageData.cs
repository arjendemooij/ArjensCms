using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arjen.Data;
using Cms.Data;
using Cms.Data.IData;
using System.Data.Entity;


namespace Cms.EntityData.Data
{
    public class PageData : BaseData<Page>, IPageData
    {
        public PageData(IRepository<Page> repository)
            : base(repository)
        {
        }


        public IEnumerable<Page> GetAllWithName(string name)
        {
            return GetBaseQuery().Where(x => x.Name == name);
        }

        public IQueryable<Page> GetBaseQuery()
        {
            return Repository.Table.Include(p=>p.Author);
        }
    }
}
