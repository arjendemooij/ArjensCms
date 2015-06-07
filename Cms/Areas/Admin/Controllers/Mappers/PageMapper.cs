using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Cms.Areas.Admin.Models;
using Cms.Controllers.Mappers;
using Cms.Data;

namespace Cms.Areas.Admin.Controllers.Mappers
{
    public class PageMapper
    {
        public void RequireMaps()
        {
            MapperHelper.RequireMap<Page, PageModel>();
            MapperHelper.RequireMap<PageModel, Page>();
            MapperHelper.RequireMap<Account, PageAuthorModel>();
            
        }

    }
}