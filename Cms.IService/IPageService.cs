using System.Collections.Generic;
using Cms.Data;

namespace Cms.IService
{
    public interface IPageService
    {
        Page GetById(int id);
        IEnumerable<Page> GetAll();
        void AddPage(Page testPage);
        bool ArePageUrlsUnique();
        void Delete(Page page);
    }
}