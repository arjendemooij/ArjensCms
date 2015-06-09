using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Cms.Models;

namespace Cms.Controllers.Mappers
{
    public class CreateAccountModelMapper
    {
        public Account ToDataModel(Account account, CreateAccountModel accountModel)
        {
            MapperHelper.RequireMap<CreateAccountModel, Account>();

            account = Mapper.Map(accountModel, account);

            account.EmailAdress = account.UserName;
            account.IsAdministrator = false;
            account.DateCreated = DateTime.Now;

            return account;
        }
    }
}