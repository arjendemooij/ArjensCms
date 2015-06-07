using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arjen.Cache;
using Arjen.Data;
using Cms.Data;
using Cms.Data.IData;

namespace Cms.EntityData.Data
{
    public class AccountData : BaseData<Account>, IAccountData
    {
        public AccountData(IRepository<Account> repository, IEntityCache entityCache)
            : base(repository, entityCache)
        {
        }

        public Account GetByUsernameAndPassword(string username, string password)
        {
            return GetBaseQuery().SingleOrDefault(acc => acc.UserName == username && acc.Password == password);
        }

        public Account GetByEmailAndPassword(string email, string password)
        {
            return GetBaseQuery().SingleOrDefault(acc => acc.EmailAdress == email && acc.Password == password);
        }

        
    }
}
