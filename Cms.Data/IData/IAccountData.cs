using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Data.IData
{
    public interface IAccountData : IData<Account>
    {
        Account  GetByUsernameAndPassword(string username, string password);
        Account GetByEmailAndPassword(string email, string password);
        
    }
}
