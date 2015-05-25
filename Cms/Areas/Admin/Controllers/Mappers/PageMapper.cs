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
        private void RequireMaps()
        {
            MapperHelper.RequireMap<Page, PageListItemModel>();
            MapperHelper.RequireMap<IEnumerable<Page>, PageListModel>();
            var expression = Mapper.CreateMap<IEnumerable<Page>, PageListModel>();
            expression.ConvertUsing(
                pages => new PageListModel()
                    {
                        ItemCount = pages.Count(),
                        Items = Mapper.Map<IEnumerable<Page>, IEnumerable<PageListItemModel>>(pages)
                    }
                );
        }

        public PageListModel MapToPageListModel(IEnumerable<Page> pages, PageListModel viewModel)
        {
            RequireMaps();

            viewModel = Mapper.Map(pages, viewModel);

            return viewModel;
        }
    }
}