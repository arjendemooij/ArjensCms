using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cms.Models
{
    public class CreateAccountModel
    {
        [Required]  
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}