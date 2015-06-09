using System.Collections.Generic;
using Arjen.Helpers;
using Cms.Models;

namespace Cms.IService
{
    public interface IPageService
    {
        Page GetById(int id);
        IEnumerable<Page> GetAll();
        void AddPage(Page testPage);
        bool ArePageUrlsUnique();
        void Delete(Page page);
        PagedList<Page> GetAll(int pageNumber, int pageSize);
        void SavePage(Page page);
    }
}