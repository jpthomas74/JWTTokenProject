using JWT.IDP.IDPModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.IDP.Services
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterModel model);
        Task<AuthenticationModel> CheckPasswordAsync(LoginRequestModel model); // New Function
        Task<AuthenticationModel> GetTokenOnlyAsync(TokenRequestModel requestModel); //New Function
        Task<ApplicationUser> GetApplicationUserAsync(LoginRequestModel model);
        Task<AuthenticationModel> GetTokenAsync(LoginRequestModel model);
        Task<AuthenticationModel> RefreshTokenAsync(string token);
        ApplicationUser GetById(string id);
        bool RevokeToken(string token);
    }
}
