using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cms.Areas.Admin.Controllers.Mappers
{
    public class AutoMapperConfigurator
    {
        public void Configure()
        {
            new PageMapper().RequireMaps();
        }
    }
}