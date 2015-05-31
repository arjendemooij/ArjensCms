using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cms.Areas.Admin.Models
{
    public class PageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string SeoUrl { get; set; }
        public string Excerpt { get; set; }
        [Required]
        public string Contents { get; set; }
        [Required]
        public string Author { get; set; }

    }

}