using System;
using System.ComponentModel.DataAnnotations;
using Arjen.Data;

namespace Cms.Models
{
    public class Page : BaseEntity, IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string SeoUrl { get; set; }

        public string Excerpt { get; set; }      
  
        [Required]
        public string Contents { get; set; }
        
        [Required]
        public Account Author { get; set; }
        
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime DateChanged { get; set; }

        public string BackgroundColor { get; set; }

    }
}
