using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cms.Data;
using Cms.Data.IData;
using Cms.IService;

namespace Cms.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountData _accountData;

        public AccountService(IAccountData accountData)
        {
            _accountData = accountData;
        }

        public IEnumerable<Account> GetAll()
        {
            return _accountData.GetAll().ToList();
        }

        public void Persist(Account account)
        {
            if (account.Id == 0)
                _accountData.Add(account);
            else
            {
                _accountData.Update(account);
            }
        }

        public bool AreValidCredentials(string usernameOrLogin, string password)
        {
            var account = _accountData.GetByUsernameAndPassword(usernameOrLogin, password)
                          ?? _accountData.GetByEmailAndPassword(usernameOrLogin, password);

            return account != null;

        }
    }
}
