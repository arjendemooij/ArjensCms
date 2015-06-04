using System;
using System.Linq;
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
        private IAccountService _accountService;

        public TestService(IPageData pageData, IAccountService accountService)
        {
            _pageData = pageData;
            _accountService = accountService;
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
                    Author = _accountService.GetAll().First(),
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