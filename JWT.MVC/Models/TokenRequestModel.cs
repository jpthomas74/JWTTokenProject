using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.MVC.Models
{
    public class TokenRequestModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Database { get; set; }

    }
}
