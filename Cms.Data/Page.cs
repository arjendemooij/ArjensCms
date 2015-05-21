using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cms.Data.IData;

namespace Cms.Data
{
    public class Page : IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contents { get; set; }
        public DateTime DateCreated { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string SeoUrl { get; set; }
    }
}
