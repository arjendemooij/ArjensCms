using System.Collections.Generic;
using System.Linq;

namespace Cms.Data.IData
{
    public interface IPageData : IData<Page>
    {
        IEnumerable<Page> GetAllWithName(string name);
        
    }
}
