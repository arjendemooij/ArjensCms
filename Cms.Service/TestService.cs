using System;
using Arjen.Data.UnitOfWork;
using Arjen.IOC;
using Cms.Data;
using Cms.Data.IData;
using Cms.IService;

namespace Cms.Service
{
    public class TestService : ITestService
    {
        private IPageData _pageData;

        public TestService(IPageData pageData)
        {
            _pageData = pageData;
        }


        public void TestAuditing()
        {
            var testPages = _pageData.GetAllWithName("Test");
            foreach (var page in testPages)
            {
                _pageData.Delete(page);
            }


            var testPage = new Page
                {
                    Author = "Test",
                    Contents = "test",
                    DateCreated = DateTime.Now,
                    Name = "Test",
                    SeoUrl = "test"
                };
            _pageData.Add(testPage);

            IOCController.GetInstance<IUnitOfWork>().Save();        
        }



    }
}