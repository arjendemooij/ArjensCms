using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arjen.Data;
using Arjen.Helpers;
using Cms.Data;
using Cms.Data.IData;
using Cms.IService;

namespace Cms.Service
{
    public class PageService : IPageService
    {
        private readonly IPageData _pageData;

        public PageService(IPageData pageData)
        {
            _pageData = pageData;
        }

        public Page GetById(int id)
        {
            return _pageData.GetById(id);
        }

        public IEnumerable<Page> GetAll()
        {
            return _pageData.GetAll();
        }

        public void AddPage(Page testPage)
        {
            testPage.DateCreated = DateTime.Now;
            testPage.DateChanged = DateTime.Now;

            _pageData.Add(testPage);
        }

        public bool ArePageUrlsUnique()
        {
            return _pageData.GetBaseQuery().Select(p => p.SeoUrl).Distinct().Count() ==
                            _pageData.GetBaseQuery().Count();
        }

        public void Delete(Page page)
        {
            _pageData.Delete(page);
        }

        public PagedList<Page> GetAll(int pageNumber, int pageSize)
        {
            var query = _pageData.GetBaseQuery().OrderBy(p => p.Id);

            var pages = new PagedList<Page>
                {
                    PageCount = (int)Math.Ceiling(query.Count() / (double)pageSize),
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Data = query.Skip((pageNumber) * pageSize).Take(pageSize).ToList()
                };


            return pages;
        }

        public void SavePage(Page page)
        {

        }
    }
}
