using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cms.Data.IData;

namespace Cms.Data
{
    public class Account : IHasId
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string EmailAdress { get; set; }
        [Required]
        public string UserName { get; set; }
        public bool IsAdministrator { get; set; }
    }
}
