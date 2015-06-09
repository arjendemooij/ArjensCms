using System.Collections.Generic;
using System.Linq;
using Arjen.Data.Repository;
using Cms.IService;
using Cms.Models;

namespace Cms.Service
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _accountRepository;

        public AccountService(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IEnumerable<Account> GetAll()
        {
            return _accountRepository.Query().Get().ToList();
        }

        public void Persist(Account account)
        {
            if (account.Id == 0)
                _accountRepository.InsertGraph(account);
            else
            {
                _accountRepository.Update(account);
            }
        }

        public bool AreValidCredentials(string usernameOrLogin, string password)
        {
            var account = GetByUsernameAndPassword(usernameOrLogin, password)
                          ?? _GetByEmailAndPassword(usernameOrLogin, password);

            return account != null;

        }

        private Account _GetByEmailAndPassword(string email, string password)
        {
            return _accountRepository
                .Query()
                .Filter(acc => acc.EmailAdress == email && acc.Password == password)
                .Get()
                .Single();
        }

        private Account GetByUsernameAndPassword(string username, string password)
        {
            return _accountRepository
                .Query()
                .Filter(acc => acc.UserName == username && acc.Password == password)
                .Get()
                .Single();
        }

        public Account GetById(int id)
        {
            return _accountRepository.FindById(id);
        }

        
    }
}
