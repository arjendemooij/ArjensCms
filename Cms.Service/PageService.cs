using System;
using System.Collections.Generic;
using System.Linq;
using Arjen.Data;
using Arjen.Data.Repository;
using Arjen.Helpers;
using Cms.IService;
using Cms.Models;

namespace Cms.Service
{
    public class PageService : IPageService
    {
        private readonly IRepository<Page> _pageRepository;

        private RepositoryQuery<Page> GetBaseQuery()
        {
            return _pageRepository.Query().Include(p => p.Author);
        }

        public PageService(IRepository<Page> pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public Page GetById(int id)
        {
            return _pageRepository.FindById(id);
        }

        public IEnumerable<Page> GetAll()
        {
            return GetBaseQuery().Get();
        }

        public void AddPage(Page testPage)
        {
            testPage.DateCreated = DateTime.Now;
            testPage.DateChanged = DateTime.Now;

            _pageRepository.InsertGraph(testPage);
        }

        public bool ArePageUrlsUnique()
        {
            return GetBaseQuery().Get().Select(p => p.SeoUrl).Distinct().Count() ==
                            _pageRepository.Query().Get().Count();
        }

        public void Delete(Page page)
        {
            _pageRepository.Delete(page);
        }

        public PagedList<Page> GetAll(int pageNumber, int pageSize)
        {
            int pageCount;
            var query = GetBaseQuery().OrderBy(q => q.OrderByDescending(page => page.Id)).GetPage(pageNumber, pageSize, out pageCount).ToList();

            var pages = new PagedList<Page>
                {
                    PageCount = pageCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Data = query.ToList()
                };

            return pages;
        }

        public void SavePage(Page page)
        {
            _pageRepository.Update(page);
        }
    }
}
