using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.MVC.Models
{
    public class LoginRequestModel
    {
        [Required]
        public string EmailOrName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
