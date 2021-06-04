using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.IDP.IDPModels
{
    public class RevokeTokenRequest
    {
        public string Token { get; set; }
    }
}
