using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Cms.Data;
using Cms.Models;

namespace Cms.Controllers.Mappers
{
    public class PageModelMapper
    {
        public PageModel MapToPageModel(Page page, PageModel model)
        {
            if(model == null)
                model = new PageModel();

            MapperHelper.RequireMap<Page, PageModel>();

            model = Mapper.Map(page, model);         

            return model;
        }
    }
}