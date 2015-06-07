using System.Collections.Generic;
using Cms.Data;

namespace Cms.IService
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAll();
        void Persist(Account account);
        bool AreValidCredentials(string usernameOrEmail, string password);
        Account GetById(int id);
        
    }
}