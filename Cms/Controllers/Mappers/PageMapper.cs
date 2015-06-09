using AutoMapper;
using Cms.Models;

namespace Cms.Controllers.Mappers
{
    public class PageMapper
    {
        public PageModel MapToPageModel(Page page, PageModel model)
        {
            MapperHelper.RequireMap<Page, PageModel>();

            model = Mapper.Map(page, model);         

            return model;
        }
    }
}