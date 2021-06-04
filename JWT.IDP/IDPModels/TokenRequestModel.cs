using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.IDP.IDPModels
{
    public class TokenRequestModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Database { get; set; }

    }
}
