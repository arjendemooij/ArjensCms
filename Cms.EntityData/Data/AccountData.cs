using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arjen.Data;
using Cms.Data;
using Cms.Data.IData;

namespace Cms.EntityData.Data
{
    public class AccountData : BaseData<Account>, IAccountData
    {
        public AccountData(IRepository<Account> repository) : base(repository)
        {
        }
    }
}
