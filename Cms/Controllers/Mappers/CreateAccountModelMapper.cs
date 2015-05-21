using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Cms.Data;
using Cms.Models;

namespace Cms.Controllers.Mappers
{
    public class CreateAccountModelMapper
    {
        public Account ToDataModel(Account account, CreateAccountModel accountModel)
        {
            if (account == null) account = new Account();

            if (Mapper.FindTypeMapFor<CreateAccountModel, Account>() == null)
            {
                Mapper.CreateMap<CreateAccountModel, Account>();
            }

            account = Mapper.Map(accountModel, account);

            return account;
        }
    }
}