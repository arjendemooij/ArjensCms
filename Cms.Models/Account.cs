using System;
using System.ComponentModel.DataAnnotations;
using Arjen.Data;

namespace Cms.Models
{
    public class Account : IHasId
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAdress { get; set; }
        [Required]
        public string UserName { get; set; }
        public bool IsAdministrator { get; set; }

        [Required]  
        public DateTime DateCreated { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
