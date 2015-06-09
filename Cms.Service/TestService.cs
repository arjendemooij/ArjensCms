using System;
using System.Collections.Generic;
using System.Linq;
using Arjen.Data;
using Arjen.Data.Repository;
using Arjen.IOC;
using Cms.IService;
using Cms.Models;

namespace Cms.Service
{
    public class TestService : ITestService
    {
        private IRepository<Page> _pageRepository;
        private IAccountService _accountService;

        public TestService(IRepository<Page> pageRepository, IAccountService accountService)
        {
            _pageRepository = pageRepository;
            _accountService = accountService;
        }




        public void TestAuditing()
        {
            var testPages = GetAllWithName("Test");
            foreach (var page in testPages)
            {
                _pageRepository.Delete(page);
            }


            var testPage = new Page
                {
                    Author = _accountService.GetAll().First(),
                    Contents = "test",
                    DateCreated = DateTime.Now,
                    Name = "Test",
                    SeoUrl = "test"
                };
            _pageRepository.InsertGraph(testPage);

            IOCController.GetInstance<IUnitOfWork>().Save();        
        }

        private IEnumerable<Page> GetAllWithName(string name)
        {
            return _pageRepository.Query().Filter(p => p.Name == name).Get();
        }
    }
}