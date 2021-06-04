using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace JWT.IDP.IDPModels
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public List<AccessibleDb> AccessibleDbs { get; set; }
    }
}
